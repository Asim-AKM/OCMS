using System;

namespace OCMS.Areas.Users.DTO_s
{
    public class AddUserCredentialsDTO
    {
        public Guid CreadId { get; set; }
        public Guid UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
    }
}