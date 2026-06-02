using Microsoft.EntityFrameworkCore;
using OCMS.Areas.Users.Models;
using OCMS.Data;
using System;
using System.Linq;

namespace OCMS.Repositories
{
    public class UserCredentialsRepo
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public bool Add(UserCreadentials userCreadentials)
        {
            _context.Add(userCreadentials);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(Guid id)
        {
            var UserCreadentialRecord = _context.UserCreadentials.Where(x => x.UserId == id).FirstOrDefault();
            _context.UserCreadentials.Remove(UserCreadentialRecord);
            _context.SaveChanges();
            return true;
        }
        public UserCreadentials GetByUserId(Guid userId)
        {
            return _context.UserCreadentials
                           .FirstOrDefault(u => u.UserId == userId);
        }
        public int UpdateOtp(UserCreadentials usercread)
        {
            _context.UserCreadentials.Attach(usercread);
            _context.Entry(usercread).Property(x => x.Otp).IsModified = true;
            _context.SaveChanges();
            return 1;
        }
        public void UpdatePassword(UserCreadentials usercread)
        {
            _context.UserCreadentials.Attach(usercread);
            _context.Entry(usercread).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}