using OCMS.Common.CommonClasses.Enums;
using OCMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace OCMS.UserRoleAuth
{
    public class RoleAuthorization : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string userId)
        {

            using (var context = new ApplicationDbContext())
            {
                var result = from ur in context.UserRoles
                             join u in context.Users on ur.UserId equals u.UserId
                             where u.UserId == Guid.Parse(userId)
                             select ((UserRoles)ur.Role).ToString();
                return result.ToArray();
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}