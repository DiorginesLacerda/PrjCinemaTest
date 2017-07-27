using System;
using System.Web.Mvc;

namespace PrjCinema.MVC.Controllers
{
    //[CustomAuthorize(UserRole = "Administrador")]
    [AllowAnonymous]
    public class HomeController : Controller
    {

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