using Microsoft.EntityFrameworkCore;
using OCMS.Data;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCMS.Repositories
{
    public class UserRoleRepo
    {
        private  readonly ApplicationDbContext _context = new ApplicationDbContext();
        public bool Add(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(UserRole userRole) 
        {
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
            return true;
        }
        public UserRole GetByUserId(Guid userId)
        {
           return _context.UserRoles.AsNoTracking().Where(r => r.UserId == userId).FirstOrDefault();
        }
        public List<UserRole> GetAll() 
        {
            return _context.UserRoles.ToList();
        }
        public bool UpdateUserRole(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            _context.SaveChanges();
            return true;
        }
    }
}