using System.Net;
using System.Web.Mvc;

namespace PBP_Frontend.Controllers
{
    [Authorize]
    [OutputCache(NoStore = false, Duration = 0)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string searchSafeCod = Dns.GetHostName();
            IPAddress[] safeCod = Dns.GetHostAddresses(searchSafeCod);
            foreach (IPAddress iP in safeCod)
            {
                int? peaces = iP?.ToString()?.Split('.')?.Length as int?;
                if (peaces != null && peaces == 4)
                {
                    ViewBag.SafeCod = iP;
                    break;
                }
            }
            return View();
        }
    }
}