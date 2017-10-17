using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TallerDeMotos.Controllers
{
    public class FacturaCompraController : Controller
    {
        // GET: FacturaCompra
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FacturaCompraFormulario()
        {
            return View();
        }
    }
}