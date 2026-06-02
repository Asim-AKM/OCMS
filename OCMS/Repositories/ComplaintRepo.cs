using Microsoft.EntityFrameworkCore;
using OCMS.Common.CommonClasses.Enums;
using OCMS.Data;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCMS.Repositories
{

    public class ComplaintRepo
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public int Add(Complaint complaint)
        {
            _context.Complaints.Add(complaint);
            _context.SaveChanges();
            return 1;
        }
        public List<Complaint> GetAll()
        {
            return _context.Complaints.ToList();
        }
        public List<Complaint> GetAllByStatus(ComplaintStatusReq statusReq)
        {
            return _context.Complaints.Where(c => c.Status == (ComplaintStatus)statusReq).ToList();
        }
        public List<Complaint> GetByUserId(Guid userId)
        {
            return _context.Complaints.Where(c => c.UserId == userId).ToList();
        }
        public Complaint GetCompById(Guid compId)
        {
            return _context.Complaints.AsNoTracking().Where(c => c.ComplaintId == compId).FirstOrDefault();
        }
        public OperationResponse UpdateStatus(Complaint complaint)
        {
            _context.Complaints.Update(complaint);
            _context.SaveChanges();
            return OperationResponse.Success;
        }

        public Complaint GetCompByTrackId(Guid userId, string trackId)
        {
            var complaint = _context.Complaints.Where(u => u.UserId == userId).ToList().Where(t => t.TrackId == trackId).FirstOrDefault();
            return complaint ?? null;
        }
        public int GetTotalCount()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Complaints.Count();
            }
        }

        public int GetCountByStatus(ComplaintStatus status)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Complaints.Count(c => c.Status == status);
            }
        }
    }
}