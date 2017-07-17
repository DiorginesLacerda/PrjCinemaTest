using System;
using System.Web.Mvc;
using PrjCinema.MVC.Session;

namespace PrjCinema.MVC.Controllers
{
    [CustomAuthorize(UserRole = "Administrador")]
    public class HomeController : Controller
    {
        [CustomAuthorize(UserPermissions = "Visualizar")]
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return RedirectToAction("Login", "Login");
            }
            
            
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