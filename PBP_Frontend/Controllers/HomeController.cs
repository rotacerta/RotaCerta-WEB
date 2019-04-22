using System.Web.Mvc;

namespace PBP_Frontend.Controllers
{
    [Authorize]
    [OutputCache(NoStore = false, Duration = 0)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}