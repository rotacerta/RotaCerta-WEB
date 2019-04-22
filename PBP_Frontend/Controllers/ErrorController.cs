using System.Web.Mvc;

namespace PBP_Frontend.Controllers
{
    [OutputCache(NoStore = false, Duration = 0)]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error404()
        {
            return View();
        }
    }
}