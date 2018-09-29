using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;


namespace TallerDeMotos.Controllers
{
    public class ProductoController : Controller
    {
        private ApplicationDbContext _context;
        private ProductoServicio productoServicio;

        public ProductoController()
        {
            _context = new ApplicationDbContext();
            productoServicio = new ProductoServicio();
        }

        // GET: Producto
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeProductos");

            return View("ListaDeProductosSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult NuevoProducto()
        {
            var viewModel = new ProductoViewModel
            {
                ProductoTipos = _context.ProductoTipos.ToList(),
                Marcas = _context.Marcas.ToList()
            };

            return View("ProductoFormulario", viewModel);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductoViewModel(producto)
                {
                    ProductoTipos = _context.ProductoTipos.ToList(),
                    Marcas = _context.Marcas.ToList()
                };

                return View("ProductoFormulario", viewModel);
            }

            if (producto.MarcaId > 0)
            {
                var marca = _context.Marcas.Find(producto.MarcaId);
                _context.Marcas.Attach(marca);
                producto.Marca = marca;
            }

            if (producto.Id == 0)           
                _context.Productos.Add(producto);
            else
            {
                var productoBD = _context.Productos
                    .Include(p => p.Marca)
                    .Single(a => a.Id == producto.Id);

                Mapper.Map<Producto, Producto>(producto, productoBD);
                productoBD.Marca = producto.Marca;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult EditarProducto(int id)
        {
            var productoBD = _context.Productos
                .Include(p => p.Marca)
                .SingleOrDefault(c => c.Id == id);

            if (productoBD == null)
                return HttpNotFound();

            var producto = new ProductoViewModel(productoBD)
            {
                ProductoTipos = _context.ProductoTipos.ToList(),
                Marcas = _context.Marcas.ToList()
            };

            return View("ProductoFormulario", producto);
        }

        public ActionResult ObtenerProductos()
        {
            return Json(productoServicio.Read(), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CrearProducto(ProductoDto productoDto)
        {
            if (productoDto != null)
            {
                productoServicio.Create(productoDto);
            }

            return Json(productoDto, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarProducto(ProductoDto productoDto)
        {
            if (productoDto != null && ModelState.IsValid)
            {
                productoServicio.Update(productoDto);
            }

            return Json(productoDto, JsonRequestBehavior.AllowGet);
        }
    }
}