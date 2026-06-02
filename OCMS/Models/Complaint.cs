using OCMS.Common.CommonClasses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMS.Models
{
    public class Complaint
    {
        [Key]
        public Guid ComplaintId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public ComplaintStatus? Status { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string TrackId { get; set; }
    }

}