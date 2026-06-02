using OCMS.Areas.Users.DTO_s;
using OCMS.Areas.Users.DTO_s.UsersDto_s;
using OCMS.Common.CommonClasses;
using OCMS.Common.CommonClasses.Enums;
using OCMS.DTO_s.AdminDashBoard;
using OCMS.DTO_s.ForgetPasswordDto_s;
using OCMS.DTO_s.UserProfileDto_s;
using OCMS.DTO_s.UsersDto_s;
using OCMS.Mappers.UsersTable;
using OCMS.Models;
using OCMS.Repositories;
using System;
using System.Collections.Generic;

namespace OCMS.Services
{
    public class UsersServices
    {

        private readonly UsersRepo _usersRepo = new UsersRepo();
        private readonly UserCredntialsService _userCredntialsSer = new UserCredntialsService();
        private readonly UserRoleServices _roleSer = new UserRoleServices();
        private readonly UserMappers _mappers = new UserMappers();
        private readonly ComplaintRepo _complaintRepo = new ComplaintRepo();

        public OperationResponse Add(AddUserDTO addUserDTO)
        {

            if (_usersRepo.EmailExistance(addUserDTO.Email)) { return OperationResponse.DuplicateRecord; }

            //map to Actual Model
            var UserDomain = _mappers.MapToAddUser(addUserDTO);

            //insert Data into tables
            if (_usersRepo.Add(UserDomain) &&
            _userCredntialsSer.Add(addUserDTO.Password, UserDomain.UserId) &&
            _roleSer.Add(UserDomain.UserId))
            {
                return OperationResponse.Success;
            }
            return OperationResponse.Failure;
        }
        public OperationResponse AddByAdmin(AddUserByAdminDTO dto, Guid currentAdminId)
        {
            if (_usersRepo.EmailExistance(dto.Email))
                return OperationResponse.DuplicateRecord;

            var adminCredentials =
                UserCredntialsService.GetByUserId(currentAdminId);

            bool isPasswordCorrect =
                PaswordServices.VerifyPassword(
                    dto.CurrentAdminPassword,
                    adminCredentials.PasswordHash,
                    adminCredentials.PasswordSalt
                );

            if (!isPasswordCorrect)
            {
                return OperationResponse.AdminPasswordIncorect;
            }

            var addUserDto = new AddUserDTO
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                ImageFile = dto.ImageFile
            };

            var userDomain = _mappers.MapToAddUser(addUserDto);

            if (_usersRepo.Add(userDomain) && _userCredntialsSer.Add(dto.Password, userDomain.UserId))
            {
                _roleSer.AddRoleByAdmin(userDomain.UserId, dto.Role);
                return OperationResponse.Success;
            }

            return OperationResponse.Failure;
        }

        public OperationResponse Delete(Guid userId)
        {
            var userDomain = GetById(userId);
            if (_usersRepo.Delete(userDomain) &&
              _userCredntialsSer.Delete(userId) &&
              _roleSer.Delete(userDomain.UserId))
            {
                ImageService.DeleteImageFile(userDomain.ImageLink);
                return OperationResponse.Success;
            }
            return OperationResponse.Failure;
        }

        public int UpdateUserStatus(UpdateUserStatusDto userStatusDto)
        {
            var user = GetById(userStatusDto.UserId);
            return _usersRepo.Update(_mappers.MapAndUpdateUserStatus(user, userStatusDto.UserStatus));

        }

        public OperationResponse UpdateUserRole(Guid userId, UserRoles role)
        {
            return _roleSer.UpdateRole(userId, role) == true ? OperationResponse.Success : OperationResponse.Failure;
        }

        public User GetById(Guid UserId)
        {
            return _usersRepo.UserGetById(UserId);
        }

        public IEnumerable<GetAllUserDTO> GetUsers(UserStatusType statusType)
        {
            var users = _usersRepo.GetUsers(statusType);
            return _mappers.MapToGetAllUserDto(users, _roleSer.GetAll());
        }

        public OperationResponse LoginCheck(LoginDTO loginDTO, out Guid userId)
        {
            var UserDomain = _usersRepo.CheckEmail(loginDTO.Email);
            if (UserDomain != null)
            {
                var UserCreadentialDomain = UserCredntialsService.GetByUserId(UserDomain.UserId);
                //Check Password
                var result = PaswordServices.VerifyPassword(loginDTO.Password, UserCreadentialDomain.PasswordHash, UserCreadentialDomain.PasswordSalt);
                if (result)
                {
                    //out the Cookies Parameter
                    userId = UserDomain.UserId;
                    return OperationResponse.Success;
                }

            }
            userId = Guid.Empty;
            return OperationResponse.Failure;

        }

        public OperationResponse VerifyEmail(VerifyEmailDTO verifyEmailDTO, out Guid userId)
        {
            var user = _usersRepo.CheckEmail(verifyEmailDTO.Email);
            if (user != null)
            {
                var random = new Random();
                var otp = random.Next(10000, 99999);
                if (UserCredntialsService.UpdateOtp(user.UserId, otp.ToString()) == 1)
                {
                    EmailServices email = new EmailServices();
                    var result = email.SendEmail(verifyEmailDTO.Email, "Don't Share your Otp with AnyOne " + otp, "ForgetPassword");
                    if (result == 1)
                    {
                        userId = user.UserId;
                        return OperationResponse.Success;
                    }
                }
                userId = Guid.Empty;
                return OperationResponse.Failure;
            }
            userId = Guid.Empty;
            return OperationResponse.Failure;
        }

        public OperationResponse UpdateProfile(UpdateProfileDTO dto)
        {
            var user = GetById(dto.UserId);
            if (user == null) return OperationResponse.Failure;

            if (dto.ImageFile != null)
            {
                ImageService.DeleteImageFile(user.ImageLink);
                user.ImageLink = ImageService.SaveAndReturnPath(dto.ImageFile);
            }

            user.FullName = dto.FullName;
            return _usersRepo.Update(user) > 0 ? OperationResponse.Success : OperationResponse.Failure;
        }

        public OperationResponse ChangePassword(ChangePasswordDTO dto)
        {
            var credentials = UserCredntialsService.GetByUserId(dto.UserId);
            if (credentials == null) return OperationResponse.Failure;

            var isCurrentValid = PaswordServices.VerifyPassword(dto.CurrentPassword, credentials.PasswordHash, credentials.PasswordSalt);
            if (!isCurrentValid) return OperationResponse.Failure;

            var updateDto = new UpdatePasswordDTO
            {
                UserId = dto.UserId,
                NewPassword = dto.NewPassword,
                Otp = credentials.Otp
            };

            var result = UserCredntialsService.UpdatePassword(updateDto);
            return result;
        }

        public UserProfileDTO GetProfileById(Guid userId)
        {
            var user = GetById(userId);
            if (user == null) return null;

            return new UserProfileDTO
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                ImageLink = user.ImageLink,
                Status = user.Status,
                CreadDate = user.CreadDate
            };
        }

        public DashboardDTO GetDashboardStats()
        {
            return new DashboardDTO
            {
                TotalUsers = _usersRepo.GetTotalCount(),
                TotalApprovedUsers = _usersRepo.GetCountByStatus(UserStatus.Approved),
                TotalPendingUsers = _usersRepo.GetCountByStatus(UserStatus.Pending),
                TotalRejectedUsers = _usersRepo.GetCountByStatus(UserStatus.Rejected),
                TotalSuspendedUsers = _usersRepo.GetCountByStatus(UserStatus.Suspended),
                TotalComplaints = _complaintRepo.GetTotalCount(),
                PendingComplaints = _complaintRepo.GetCountByStatus(ComplaintStatus.Pending),
                InProgressComplaints = _complaintRepo.GetCountByStatus(ComplaintStatus.InProgress),
                ResolvedComplaints = _complaintRepo.GetCountByStatus(ComplaintStatus.Resolved),
                RejectedComplaints = _complaintRepo.GetCountByStatus(ComplaintStatus.Rejected),
                ApprovedComplaints = _complaintRepo.GetCountByStatus(ComplaintStatus.Approved)
            };
        }


    }
}
