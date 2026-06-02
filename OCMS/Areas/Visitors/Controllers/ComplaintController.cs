using OCMS.Authantication;
using OCMS.Common.CommonClasses.Enums;
using OCMS.DTO_s.ComplaintDto_s;
using OCMS.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OCMS.Areas.Visitors.Controllers
{
    [Authorize]
    public class ComplaintController : Controller
    {
        private readonly ComplaintService _services = new ComplaintService();
        public ActionResult ComplaintPage()
        {
            return View();
        }
        [HttpPost]
        [AuthorizeUser(checkStatus: true)]
        public ActionResult RegisterComplaint(AddComplaintDTO request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );
                return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.AllowGet);
            }

            request.UserId = Guid.Parse(User.Identity.Name);
            var result = _services.RegisterComplaint(request, out string trackId);

            if (result == OperationResponse.Success)
            {
                return Json(new { Success = true, TrackId = trackId }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Success = false, TrackId = (string)null }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TrackComplaintPage()
        {
            return View();
        }

        public ActionResult TrackComplaint(TrackComplaintDto request)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Where(e => e.Value.Errors.Count > 0).ToDictionary(
                    k => k.Key,
                    v => v.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
                return Json(new { Success = false, Error = error }, JsonRequestBehavior.AllowGet);
            }

            request.UserId = Guid.Parse(User.Identity.Name);
            var result = _services.TrackComplaint(request);

            if (result == null)
            {
                return Json(new { Found = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Found = true, Data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}