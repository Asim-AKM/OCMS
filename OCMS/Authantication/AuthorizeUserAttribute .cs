using OCMS.Common.CommonClasses.Enums;
using OCMS.Services;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace OCMS.Authantication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {
        private readonly bool _checkStatus;
        //private readonly bool _checkCookies;
        //private readonly bool _checkRole;

        private readonly UsersServices _usersServices = new UsersServices();

        public AuthorizeUserAttribute( bool checkStatus = true)
        {
            _checkStatus = checkStatus;
            //_checkCookies = checkCookies;
            //_checkRole = checkRole;
            
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Guid? userId = Guid.Parse((filterContext.HttpContext.User.Identity.Name));
            var user = _usersServices.GetById(userId.Value);
       
            if (_checkStatus && user != null)
            {
               
                if (user.Status == UserStatus.Pending ||
                    user.Status == UserStatus.Rejected ||
                    user.Status == UserStatus.Suspended)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new JsonResult
                        {
                            Data = new
                            {
                                RedirectUrl = "/Visitors/Status/UserStatus?UserId=" + userId + "&Status=" + user.Status
                            },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                        return;
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            area = "Visitors",
                            controller = "Status",
                            action = "UserStatus",
                            UserId = userId,
                            Status = user.Status.ToString()

                        }));

                        return;
                    }

                }
            }

            base.OnActionExecuting(filterContext);
        }

        //public override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //  var UserId=  filterContext.HttpContext.User.Identity.Name.ToString();
        //    if (filterContext.Result is JsonResult json)
        //    {
        //        // response mila hai ya nahi check karo
        //        var response = json.Data as OperationResponse?;

        //        // Agar login fail hua → role check skip
        //        if (response == null || response != OperationResponse.Success)
        //        {
        //            base.OnResultExecuted(filterContext);
        //            return;
        //        }

        //        // Agar login success hua → ab role check karo
        //        Guid userId = Guid.Parse(UserId);
        //        var user = _usersServices.GetById(userId);

        //        if (user != null)
        //        {
        //            if (user.Role == UserRoles.User)
        //            {
        //                if (filterContext.HttpContext.Request.IsAjaxRequest())
        //                {
        //                    filterContext.Result = new JsonResult
        //                    {
        //                        Data = new { RedirectUrl = "/Visitors/Home/Index" },
        //                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //                    };
        //                }
        //                else
        //                {
        //                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
        //                    {
        //                        area = "Visitors",
        //                        controller = "Home",
        //                        action = "Index"
        //                    }));
        //                }
        //                return;
        //            }
        //            else if (user.Role == UserRoles.Admin)
        //            {
        //                if (filterContext.HttpContext.Request.IsAjaxRequest())
        //                {
        //                    filterContext.Result = new JsonResult
        //                    {
        //                        Data = new { RedirectUrl = "/Admin/UserManager/Index" },
        //                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //                    };
        //                }
        //                else
        //                {
        //                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
        //                    {
        //                        area = "Admin",
        //                        controller = "UserManager",
        //                        action = "Index"
        //                    }));
        //                }
        //                return;
        //            }
        //        }
        //    }

        //    base.OnResultExecuted(filterContext);

        //}

    }
}
