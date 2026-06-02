using OCMS.Common.CommonClasses.Enums;
using OCMS.DTO_s.ComplaintDto_s;
using OCMS.Services;
using System;
using System.Web.Mvc;

namespace OCMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ComplaintManagerController : Controller
    {
        private readonly ComplaintService _CompServ = new ComplaintService();
        // GET: Admin/ComplaintManager
        public ActionResult ComplaintsPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetComplaints(ComplaintStatusReq statusReq)
        {
            return PartialView("_LoudComplaints", _CompServ.GetAllComplaints(statusReq));
        }
        [HttpPost]
        public ActionResult UpdateCompStatus(UpdateCompStatusDTO compStatusDTO)
        {
            var res = _CompServ.UpdateCompStatus(compStatusDTO);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetComplaintDetails(Guid complaintId)
        {
            var complaint = _CompServ.GetCompById(complaintId);

            return PartialView("_pComplaintDetails", complaint);
        }

    }
}