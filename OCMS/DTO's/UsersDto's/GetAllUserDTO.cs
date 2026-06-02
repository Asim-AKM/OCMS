using OCMS.Common.CommonClasses;
using OCMS.Common.CommonClasses.Enums;
using System;

namespace OCMS.Areas.Users.DTO_s.UsersDto_s
{
    public class    GetAllUserDTO
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserRoles? Role { get; set; }
        public UserStatus? Status { get; set; }
        public string ImageLink { get; set; }
        public DateTime? CreadDate { get; set; }
    }
}