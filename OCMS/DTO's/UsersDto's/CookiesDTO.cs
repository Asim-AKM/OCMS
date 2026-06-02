using OCMS.Common.CommonClasses.Enums;
using System;

namespace OCMS.DTO_s.UsersDto_s
{
    public class CookiesDTO
    {
        public Guid UserId { get; set; }
        public UserStatus? Status { get; set; }
    }
}