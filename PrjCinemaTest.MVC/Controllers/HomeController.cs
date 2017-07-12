using System.Web.Mvc;
using PrjCinema.Domain.Entities;

namespace PrjCinema.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Seriando";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Seriando";

            return View();
        }
    }
}