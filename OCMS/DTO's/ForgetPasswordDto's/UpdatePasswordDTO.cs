using System;

namespace OCMS.DTO_s.ForgetPasswordDto_s
{
    public class UpdatePasswordDTO
    {
        public Guid UserId { get; set; }
        public string Otp { get; set; }
        public string NewPassword { get; set; }
    }
}