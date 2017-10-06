using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TallerDeMotos.Controllers
{
    public class OrdenCompraController : Controller
    {
        // GET: OrdenCompra
        public ActionResult Index()
        {
            return View("OrdenCompraFormulario");
        }

        public ActionResult OrdenCompraReport()
        {
            return View();
        }
    }
}