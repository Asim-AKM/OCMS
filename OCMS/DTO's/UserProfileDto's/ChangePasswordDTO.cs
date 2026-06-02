using System;

namespace OCMS.DTO_s.UserProfileDto_s
{
    public class ChangePasswordDTO
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}