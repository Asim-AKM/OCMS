using OCMS.Areas.Users.DTO_s;
using OCMS.Areas.Users.DTO_s.UsersDto_s;
using OCMS.Common.CommonClasses;
using OCMS.Common.CommonClasses.Enums;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCMS.Mappers.UsersTable
{
    public class UserMappers
    {
        public IEnumerable<GetAllUserDTO> MapToGetAllUserDto(List<User> users, List<UserRole> roles)
        {
            return from u in users
                   join r in roles on u.UserId equals r.UserId
                   select new GetAllUserDTO
                   {
                       UserId = u.UserId,
                       FullName=u.FullName,
                       Email=u.Email,
                       Role=r.Role,
                       Status=u.Status,
                       ImageLink=u.ImageLink,
                       CreadDate=u.CreadDate,
                   };
        }

        public User MapToAddUser(AddUserDTO adduserDTO)
        {
            var ImagePath = ImageService.SaveAndReturnPath(adduserDTO.ImageFile);
            var users = new User()
            {
                UserId = Guid.NewGuid(),
                FullName = adduserDTO.FullName,
                Email = adduserDTO.Email,
                ImageLink = ImagePath,
                CreadDate = DateTime.Now,
                Status = UserStatus.Pending
            };
            return users;
        }
            
        public User MapAndUpdateUserStatus(User user, UserStatus newStatus)
        {
            var ActualUser = new User()
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                ImageLink = user.ImageLink,
                CreadDate = DateTime.Now,
                Status = newStatus
            };
            return ActualUser;

        }
    }
}

