using System.Web.Mvc;
using MonitorTimeActionFilterAttribute.ActionFilter;
using MonitorTimeActionFilterAttribute.Service;

namespace MonitorTimeActionFilterAttribute.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [MonitorExecutionTimeActionFilter(AlertTypes.Email)]
        public ActionResult Email()
        {
            return View();
        }

        [MonitorExecutionTimeActionFilter(AlertTypes.Line)]
        public ActionResult Line()
        {
            return View();
        }

        [MonitorExecutionTimeActionFilter(AlertTypes.All)]
        public ActionResult All()
        {
            return View();
        }
    }
}