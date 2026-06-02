using System.Web.Mvc;

namespace OCMS.Areas.Users.Controllers
{
    public class HomeController : Controller
    {
        // GET: Users/Users
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Login()
        {
            return View();
        }

        public ActionResult TrackComplaint()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }




    }

}