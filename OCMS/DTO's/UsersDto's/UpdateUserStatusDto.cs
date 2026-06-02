using OCMS.Common.CommonClasses.Enums;
using System;

namespace OCMS.DTO_s.UsersDto_s
{
    public class UpdateUserStatusDto
    {
        public Guid UserId { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}