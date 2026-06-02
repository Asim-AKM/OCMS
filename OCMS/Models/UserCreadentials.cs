using System;
using System.ComponentModel.DataAnnotations;

namespace OCMS.Areas.Users.Models
{
    public class UserCreadentials
    {
        [Key]
        public Guid CreadId { get; set; }
        public Guid UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Otp { get; set; }
    }
}