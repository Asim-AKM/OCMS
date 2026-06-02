using OCMS.Common.CommonClasses;
using OCMS.Common.CommonClasses.Enums;
using OCMS.Models;
using System;

namespace OCMS.Mappers
{
    public static class UserRoleMappers
    {
        public static UserRole MapToAddUserRole(Guid userId)
        {
            return new UserRole()
            {
                UserRoleId = Guid.NewGuid(),
                Role = UserRoles.User,
                UserId = userId,
            };
        }
        public static UserRole MapToUpdatedRole(this UserRole role, UserRoles newRole)
        {
            return new UserRole()
            {
                UserRoleId = role.UserRoleId,
                Role = newRole,
                UserId = role.UserId,
            };

        }
    }
}