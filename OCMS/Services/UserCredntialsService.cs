using OCMS.Areas.Users.Models;
using OCMS.Common.CommonClasses.Enums;
using OCMS.DTO_s.ForgetPasswordDto_s;
using OCMS.Mappers;
using OCMS.Repositories;
using System;

namespace OCMS.Services
{
    public class UserCredntialsService : UserCreaditionalMappers
    {
        private readonly static UserCredentialsRepo _repo = new UserCredentialsRepo();

        public bool Add(string password, Guid userId)
        {
            return _repo.Add(MapToAddUserCredentials(password, userId));
        }

        public bool Delete(Guid userId)
        {
            return _repo.Delete(userId);
        }

        public static UserCreadentials GetByUserId(Guid Id)
        {
            return _repo.GetByUserId(Id);
        }

        public static int UpdateOtp(Guid userId, string Otp)
        {
            var UserCread = GetByUserId(userId);
            UserCread.Otp = Otp;
            return _repo.UpdateOtp(UserCread);
        }

        public static OperationResponse UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            var userCread = GetByUserId(updatePasswordDTO.UserId);
            if (userCread == null)
                return OperationResponse.Failure;

            if (userCread.Otp == updatePasswordDTO.Otp)
            {
                MapToUpdatePassword(userCread, updatePasswordDTO.NewPassword);
                _repo.UpdatePassword(userCread);
                return OperationResponse.Success;
            }

            return OperationResponse.Failure;
        }

    }
}