using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers
{
    public class BancoController : Controller
    {
        private BancoServicio bancoServicio;

        public BancoController()
        {
            bancoServicio = new BancoServicio();
        }
        // GET: Banco
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtenerCiudades()
        {
            return Json(bancoServicio.Read(), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CrearBanco(BancoDto bancoDto)
        {
            if (bancoDto != null)
            {
                bancoServicio.Create(bancoDto);
            }

            return Json(bancoDto, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarCiudad(BancoDto bancoDto)
        {
            if (bancoDto != null && ModelState.IsValid)
            {
                bancoServicio.Update(bancoDto);
            }

            return Json(bancoDto, JsonRequestBehavior.AllowGet);
        }
    }
}