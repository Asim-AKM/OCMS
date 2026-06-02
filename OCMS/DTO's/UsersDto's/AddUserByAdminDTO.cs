using OCMS.Common.CommonClasses.Enums;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OCMS.DTO_s.UsersDto_s
{

        public class AddUserByAdminDTO
        {
            [Required]
            public string FullName { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

            public HttpPostedFileBase ImageFile { get; set; }

            [Required]
            public UserRoles Role { get; set; }

            [Required]
            public string CurrentAdminPassword { get; set; }
        }
    }
