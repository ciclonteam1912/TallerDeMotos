using System.Web.Mvc;

namespace TallerDeMotos.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AccesoDenegado()
        {
            return View();
        }
    }
}