using System.Web;
using System.Web.Mvc;

namespace PrjCinema.MVC.Session
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return true;
        }
        
    }
}