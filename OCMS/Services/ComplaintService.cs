using OCMS.Common.CommonClasses.Enums;
using OCMS.DTO_s.ComplaintDto_s;
using OCMS.Mappers;
using OCMS.Models;
using OCMS.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OCMS.Services
{
    public class ComplaintService
    {
        private readonly ComplaintRepo _complaintRepo = new ComplaintRepo();
        public OperationResponse RegisterComplaint(AddComplaintDTO request, out string trackId)
        {
            var complaint = _complaintRepo.Add(request.Map(out string newTrackId));
            trackId = newTrackId;
            return complaint < 0 ? OperationResponse.Failure : OperationResponse.Success;
        }
        public List<GetAllComplaintsDTO> GetAllComplaints(ComplaintStatusReq statusReq)
        {
            return statusReq == ComplaintStatusReq.AllComplaints
                ? (_complaintRepo.GetAll()).Map()
                : (_complaintRepo.GetAllByStatus(statusReq)).Map();
        }
        public List<Complaint> GetCompByUserId(Guid userId)
        {
            return _complaintRepo.GetByUserId(userId);
        }
        public Complaint GetCompById(Guid copmId)
        {
            return _complaintRepo.GetCompById(copmId);
        }
        public OperationResponse UpdateCompStatus(UpdateCompStatusDTO compStatusDTO)
        {
            var complaint = GetCompById(compStatusDTO.ComplaintId).UpdateStatus(compStatusDTO.Status);
            if (complaint == null)
            {
                return OperationResponse.Failure;
            }
            return _complaintRepo.UpdateStatus(complaint);
        }
        public Complaint TrackComplaint(TrackComplaintDto trackComplaintDto)
        {
            var result = _complaintRepo.GetCompByTrackId(trackComplaintDto.UserId, trackComplaintDto.TrackId);
            return result;
        }
    }


}