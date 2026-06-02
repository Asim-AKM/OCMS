using OCMS.Common.CommonClasses.Enums;
using System;

namespace OCMS.Models
{
    public class UserRole
    {
        public Guid UserRoleId { get; set; }
        public UserRoles? Role { get; set; }
        public Guid UserId { get; set; }
    }
}