using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class ProductoController : Controller
    {
        private ApplicationDbContext _context;

        public ProductoController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Producto
        public ActionResult Index()
        {
            return View("ListaDeProductos");
        }

        public ActionResult NuevoProducto()
        {
            var viewModel = new ProductoViewModel();

            return View("ProductoFormulario", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductoViewModel(producto);

                return View("ProductoFormulario", viewModel);
            }

            producto.ExistenciaActual = producto.ExistenciaInicial;
            if (producto.Id == 0)           
                _context.Productos.Add(producto);
            else
            {
                var productoBD = _context.Productos.Single(a => a.Id == producto.Id);
                Mapper.Map<Producto, Producto>(producto, productoBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditarProducto(int id)
        {
            var productoBD = _context.Productos.SingleOrDefault(c => c.Id == id);

            if (productoBD == null)
                return HttpNotFound();

            var producto = new ProductoViewModel(productoBD);

            return View("ProductoFormulario", producto);
        }
    }
}