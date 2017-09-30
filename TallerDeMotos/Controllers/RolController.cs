using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    [AutorizacionPersonalizada(Roles = RoleName.Administrador)]
    public class RolController : Controller
    {
        private ApplicationDbContext _context;

        public RolController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Rol
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();

            return View("ListaDeRoles", roles);
        }


        public ActionResult CrearRol(string message = "")
        {
            ViewBag.Message = message;
            //var rol = new IdentityRole();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearRol(RolViewModel rol)
        {
            ViewBag.Message = "Nombre de rol ya existe!";
            if (!ModelState.IsValid)
                return View(rol);

            var role = new IdentityRole { Name = rol.Name };
            var idManager = new IdentityManager();

            if (idManager.RoleExists(rol.Name))
                return View(rol);

            _context.Roles.Add(role);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditarRol(string id)
        {
            if (id == "c2625e46-98d0-42ee-9aec-d38a408ee62c")
                return RedirectToAction("Index");

            var thisRole = _context.Roles
                .Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase))
                .FirstOrDefault();

            if (thisRole == null)
                return RedirectToAction("Index");

            var viewModel = new RolViewModel(thisRole);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarRol(RolViewModel rol)
        {
            if (!ModelState.IsValid)
                return View(rol);

            var rolBD = _context.Roles.SingleOrDefault(r => r.Name == rol.OriginalRoleName);

            if (rolBD == null)
                return HttpNotFound();

            rolBD.Name = rol.Name;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ManageUserRoles()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var usrMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var account = new AccountController(usrMgr);
            account.UserManager.AddToRole(user.Id, RoleName);

            return View("ManageUserRoles");
        }

        public JsonResult ObtenerRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var account = new AccountController(userManager);

                var listaRoles = account.UserManager.GetRoles(user.Id);

                return Json(listaRoles);
            }

            return Json(UserName);
        }

        [HttpPost]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var usrMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var account = new AccountController(usrMgr);
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (account.UserManager.IsInRole(user.Id, RoleName))
            {
                account.UserManager.RemoveFromRole(user.Id, RoleName);
            }

            return View("ManageUserRoles");
        }
    }
}