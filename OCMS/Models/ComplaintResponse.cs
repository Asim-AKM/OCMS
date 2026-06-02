using System;
using System.ComponentModel.DataAnnotations;

namespace OCMS.Models
{
    public class ComplaintResponse
    {
        [Key]
        public Guid ResponseId { get; set; }
        public Guid ComplaintId { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }  
        public DateTime? ResponseDate { get; set; }
    }
}