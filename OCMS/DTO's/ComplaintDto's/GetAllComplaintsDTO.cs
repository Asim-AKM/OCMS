using OCMS.Common.CommonClasses.Enums;
using System;

namespace OCMS.DTO_s.ComplaintDto_s
{
    public class GetAllComplaintsDTO
    {
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