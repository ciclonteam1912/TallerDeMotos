using Microsoft.AspNet.Identity;
using System.Data;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;

namespace TallerDeMotos.Controllers
{
    public class FacturaVentaController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD _conexionBD;
        NuevaFacturaVentaDto viewModel;

        public FacturaVentaController()
        {
            _context = new ApplicationDbContext();
            _conexionBD = new ConexionBD();
            viewModel = new NuevaFacturaVentaDto();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: FacturaCompra
        public ActionResult Index()
        {
            return View("ListaDeFacturaDeVentas");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult FacturaVentaFormulario()
        {
            DataSet dsDatos = new DataSet();
            string usuarioId = User.Identity.GetUserId().ToString();
            dsDatos = _conexionBD.ObtenerDatosParaMovimientoCaja(usuarioId);
            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                viewModel.Resultado = true;
            }
            else
            {
                viewModel.MensajeError = "Primero debe realizar la apertura de la caja del día de hoy.";
                viewModel.Resultado = false;
            }
            return View(viewModel);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult FacturaVentaReport(int nroFactura = 0, int nroCaja = 0)
        {
            if (nroFactura != 0)
            {
                ViewBag.NumeroFactura = nroFactura;
                ViewBag.NumeroCaja = nroCaja;
            }
            return View("FacturaVentaReport");
        }
    }
}