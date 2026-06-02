using System;
using System.Web;

namespace OCMS.DTO_s.UserProfileDto_s
{
    public class UpdateProfileDTO
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}