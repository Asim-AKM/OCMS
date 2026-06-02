using OCMS.Common.CommonClasses.Enums;
using System;

namespace OCMS.DTO_s.UserProfileDto_s
{
    public class GetUserDTO
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserStatus? Status { get; set; }
        public string ImageLink { get; set; }
        public DateTime? CreadDate { get; set; }

    }
}