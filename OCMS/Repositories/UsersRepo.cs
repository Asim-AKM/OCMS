using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OCMS.Common.CommonClasses.Enums;
using OCMS.Data;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCMS.Repositories
{
    public class UsersRepo
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public bool Add(User user)
        {
            _context.Users.Add(user);
            int result = _context.SaveChanges();
            return true;
        }
        public bool EmailExistance(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public bool Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
        public int Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return 1;
        }
        public User UserGetById(Guid UserId) => _context.Users.AsNoTracking().Where(u => u.UserId == UserId).FirstOrDefault();
        public List<User> GetUsers(UserStatusType statusType)
        {
            if (statusType == UserStatusType.AllUsers || statusType > (UserStatusType)4)
            {
                return _context.Users.ToList();
            }
            return _context.Users.Where(u => u.Status == (UserStatus)statusType).ToList();
        }
        public User CheckEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }
        public int GetTotalCount()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.Count();
            }
        }

        public int GetCountByStatus(UserStatus status)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.Count(u => u.Status == status);
            }
        }
    }
}