using OCMS.Common.CommonClasses.Enums;
using System;

namespace OCMS.DTO_s.ComplaintDto_s
{
    public class UserStatusPageDto
    {
        public Guid UserId {  get; set; }
        public UserStatus? Status { get; set; }
    }
}