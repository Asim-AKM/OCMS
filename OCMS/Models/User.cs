using OCMS.Common.CommonClasses;
using OCMS.Common.CommonClasses.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OCMS.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserStatus? Status { get; set; }
        public string ImageLink { get; set; }
        public DateTime? CreadDate { get; set; }
    }
}