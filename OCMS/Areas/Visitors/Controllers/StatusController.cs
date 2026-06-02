using OCMS.DTO_s.ComplaintDto_s;
using System.Web.Mvc;

namespace OCMS.Areas.Visitors.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        // GET: Visitors/Status
        public ActionResult UserStatus(UserStatusPageDto userStatusPageDto)
        {
            
            return View(userStatusPageDto);
        }
    }
}