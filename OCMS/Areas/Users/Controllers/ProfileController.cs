using OCMS.Common.CommonClasses.Enums;
using OCMS.DTO_s.UserProfileDto_s;
using OCMS.Services;
using System;
using System.Web.Mvc;

namespace OCMS.Areas.Users.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UsersServices _userServices = new UsersServices();
        private readonly ComplaintService _complaintService = new ComplaintService();

        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.Name);
            var profile = _userServices.GetProfileById(userId);
            if (profile == null) return RedirectToAction("Login", "Auth", new { area = "Users" });
            return View(profile);
        }

        [HttpPost]
        public ActionResult UpdateProfile(UpdateProfileDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                return Json(new { Success = false, Message = "Full name is required" }, JsonRequestBehavior.AllowGet);

            dto.UserId = Guid.Parse(User.Identity.Name);
            var result = _userServices.UpdateProfile(dto);
            return Json(new { Success = result == OperationResponse.Success }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CurrentPassword) || string.IsNullOrWhiteSpace(dto.NewPassword))
                return Json(new { Success = false, Message = "All fields are required" }, JsonRequestBehavior.AllowGet);

            if (dto.NewPassword != dto.ConfirmPassword)
                return Json(new { Success = false, Message = "Passwords do not match" }, JsonRequestBehavior.AllowGet);

            dto.UserId = Guid.Parse(User.Identity.Name);
            var result = _userServices.ChangePassword(dto);

            if (result == OperationResponse.Failure)
                return Json(new { Success = false, Message = "Current password is incorrect" }, JsonRequestBehavior.AllowGet);

            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetComplaints()
        {
            var userId = Guid.Parse(User.Identity.Name);
            var complaints = _complaintService.GetCompByUserId(userId);
            return Json(complaints, JsonRequestBehavior.AllowGet);
        }
    }
}