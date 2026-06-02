using OCMS.Common.CommonClasses;
using OCMS.Common.CommonClasses.Enums;
using OCMS.DTO_s.UsersDto_s;
using OCMS.Services;
using System;
using System.Web.Mvc;

namespace OCMS.Areas.Admin.Controllers
{

    //[Authorize(Roles = "Admin")]
    public class UserManagerController : Controller
    {
        private readonly UsersServices _userServ = new UsersServices();
        private readonly ComplaintService _complaintService = new ComplaintService();
        public ActionResult Index()
        {
            var stats = _userServ.GetDashboardStats();
            return View(stats);
        }
        [HttpGet]
        public ActionResult GetAllUser()
        {
            return View();
        }
        public ActionResult GetUsersByUsingPartial(UserStatusType statusType)
        {
            return PartialView("_pTableBody", _userServ.GetUsers(statusType));
        }
        [HttpPost]
        public JsonResult DeleteUser(Guid userId)
        {
            return Json(_userServ.Delete(userId));
        }
        [HttpPost]
        public JsonResult UpdateUserStatus(UpdateUserStatusDto userStatusDto)
        {
            return Json(_userServ.UpdateUserStatus(userStatusDto));
        }
        [HttpPost]
        public JsonResult UpdateUserRole(Guid userId, UserRoles role)
        {
            return Json(_userServ.UpdateUserRole(userId, role));
        }
        [HttpPost]
        public JsonResult SaveUserByAdmin(AddUserByAdminDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(OperationResponse.ModelStateFail);

                Guid currentAdminId = Guid.Parse(User.Identity.Name);
                var result = _userServ.AddByAdmin(dto, currentAdminId);
                return Json(result);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }

    }
}