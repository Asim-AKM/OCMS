using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OCMS.Areas.Users.DTO_s
{
    public class AddUserDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public HttpPostedFileBase ImageFile {  get; set; }
    
    }
}