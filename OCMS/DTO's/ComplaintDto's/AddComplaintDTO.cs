using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OCMS.DTO_s.ComplaintDto_s
{
    public class AddComplaintDTO
    {
        [Required(ErrorMessage = "Complaint title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Submission date is required")]
        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public Guid UserId { get; set; }
    }

}