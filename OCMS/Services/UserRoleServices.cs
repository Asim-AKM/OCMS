using OCMS.Common.CommonClasses;
using OCMS.Common.CommonClasses.Enums;
using OCMS.Mappers;
using OCMS.Models;
using OCMS.Repositories;
using System;
using System.Collections.Generic;

namespace OCMS.Services
{
    public class UserRoleServices
    {
        private readonly UserRoleRepo _roleRepo = new UserRoleRepo();

        public bool Add(Guid userId)
        {
            return _roleRepo.Add(UserRoleMappers.MapToAddUserRole(userId));
        }
        public bool AddRoleByAdmin(Guid userId, UserRoles role)
        {
            var userRole = UserRoleMappers.MapToAddUserRole(userId);
            userRole.Role = role;
            return _roleRepo.Add(userRole);
        }

        public bool Delete(Guid userId)
        {
            return _roleRepo.Delete(_roleRepo.GetByUserId(userId));
        }

        public List<UserRole> GetAll()
        {
            return _roleRepo.GetAll();
        }

        public bool UpdateRole(Guid userId, UserRoles role)
        {
            var UserRole = _roleRepo.GetByUserId(userId).MapToUpdatedRole(role);
            return _roleRepo.UpdateUserRole(UserRole);
        }
    }
}