using System.Web.Mvc;

namespace PBP_Frontend.Controllers
{
   [Authorize]
   public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}