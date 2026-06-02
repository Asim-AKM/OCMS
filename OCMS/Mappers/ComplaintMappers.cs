using OCMS.Common.CommonClasses;
using OCMS.Common.CommonClasses.Enums;
using OCMS.DTO_s.ComplaintDto_s;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCMS.Mappers
{
    public static class ComplaintMappers
    {
        public static Complaint Map(this AddComplaintDTO dto, out string trackId)
        {
            if (dto == null)
            {
                trackId = string.Empty;
                return new Complaint();
            }

            var random = new Random();
            var complaint = new Complaint
            {
                ComplaintId = Guid.NewGuid(),
                UserId = dto.UserId,
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                ImagePath = ImageService.SaveAndReturnPath(dto.ImageFile),
                Status = ComplaintStatus.Pending,
                SubmissionDate = dto.SubmissionDate,
                TrackId = random.Next(1000, 9999).ToString()
            };
            trackId = complaint.TrackId;
            return complaint;
        }

        public static List<GetAllComplaintsDTO> Map(this List<Complaint> complaints)
        {
            if (complaints == null || !complaints.Any()) return new List<GetAllComplaintsDTO>();
            return complaints.Select(c => new GetAllComplaintsDTO
            {
                ComplaintId = c.ComplaintId,
                UserId = c.UserId,
                Title = c.Title,
                Description = c.Description,
                Category = c.Category,
                ImagePath = c.ImagePath,
                Status = c.Status,
                SubmissionDate = c.SubmissionDate,
                TrackId = c.TrackId
            }).ToList();
        }

        public static Complaint UpdateStatus(this Complaint complaint, ComplaintStatus complaintStatus)
        {
            if (complaint == null)
            { return null; }
            return new Complaint()
            {
                ComplaintId = complaint.ComplaintId,
                UserId = complaint.UserId,
                Title = complaint.Title,
                Description = complaint.Description,
                Category = complaint.Category,
                ImagePath = complaint.ImagePath,
                Status = complaintStatus,
                SubmissionDate = complaint.SubmissionDate,
                TrackId = complaint.TrackId
            };
        }

    }
}