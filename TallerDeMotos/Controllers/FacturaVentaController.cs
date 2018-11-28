using Microsoft.AspNet.Identity;
using System.Data;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Filters;
using TallerDeMotos.Models;

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
            string usuario = User.Identity.Name;
            if (_conexionBD.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION("Crear Factura de Venta") || usuario.Equals("admin"))
                ViewBag.CrearFacturaVenta = true;
            else
                ViewBag.CrearFacturaVenta = false;

            return View("ListaDeFacturaDeVentas");
        }

        [HasPermission("Crear Factura de Venta")]
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

        public ActionResult FacturaVentaReport(int nroFactura = 0, int nroCaja = 0)
        {
            if (nroFactura != 0)
            {
                ViewBag.NumeroFactura = nroFactura;
                ViewBag.NumeroCaja = nroCaja;
            }
            return View("FacturaVentaReport");
        }

        public ActionResult FacturaVentasGeneradasReport()
        {

            return View("FacturaVentasGeneradasReport");
        }
    }
}