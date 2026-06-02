using System.Web.Mvc;

namespace OCMS.Areas.Visitors.Controllers
{
    
    public class HomeController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}