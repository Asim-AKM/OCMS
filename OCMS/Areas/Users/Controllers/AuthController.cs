using OCMS.Areas.Users.DTO_s;
using OCMS.Common.CommonClasses.Enums;
using OCMS.DTO_s.ForgetPasswordDto_s;
using OCMS.DTO_s.UsersDto_s;
using OCMS.Services;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OCMS.Areas.Users.Controllers
{

    public class AuthController : Controller
    {
        private readonly UsersServices _userservice = new UsersServices();
        // GET: Users/Account
        public ActionResult RegistrationPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveUsers(AddUserDTO addUserDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(3, JsonRequestBehavior.AllowGet);
                }


                return Json(_userservice.Add(addUserDTO), JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Visitors/Home/Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult LoginCheck(LoginDTO loginDTO)
        {
            var response = _userservice.LoginCheck(loginDTO, out Guid userId);

            if (response == OperationResponse.Success)
            {
                bool rememberMe = Request.Form["RememberMe"] == "true";
                SetAuthCookie(userId, rememberMe);
                return Json(response, JsonRequestBehavior.AllowGet);
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        private void SetAuthCookie(Guid userId, bool rememberMe)
        {
            int days = rememberMe ? 30 : 7;

            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: userId.ToString(),
                issueDate: DateTime.Now,
                expiration: DateTime.Now.AddDays(days),
                isPersistent: true,
                userData: string.Empty
            );

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
            {
                Expires = DateTime.Now.AddDays(days),
                HttpOnly = true
            };

            Response.Cookies.Add(cookie);
        }

        public ActionResult VerifyEmailPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmailVerification(VerifyEmailDTO verifyEmailDTO)
        {
            var result = _userservice.VerifyEmail(verifyEmailDTO, out Guid userId);
            TempData["userId"] = userId;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdatePasswordPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateNewPassword(UpdatePasswordDTO updatePasswordDTO)
        {
            var result = UserCredntialsService.UpdatePassword(updatePasswordDTO);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return Redirect("/Users/Auth/Login");
        }
    }
}