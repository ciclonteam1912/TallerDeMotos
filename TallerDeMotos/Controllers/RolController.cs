using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
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


        public ActionResult CrearRol()
        {
            var permisos = _context.Permisos.ToList().OrderBy(p => p.Id);
            var viewModel = new RolViewModel();
            viewModel.Permisos = new List<SelectListItem>();
            foreach (var permiso in permisos)
            {
                viewModel.Permisos.Add(new SelectListItem
                {
                    Text = permiso.Descripcion,
                    Value = permiso.Id.ToString()
                });
            }


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearRol(RolViewModel rol)
        {
            if (!ModelState.IsValid)
                return View(rol);

            var role = new ApplicationRole { Name = rol.Name, Descripcion = rol.Descripcion };
            var idManager = new IdentityManager();

            if (idManager.RoleExists(rol.Name))
                return View(rol);

            List<Permisos> permisos = new List<Permisos>();
            int id = 0;
            foreach (var permiso in rol.Permisos)
            {
                if (permiso.Selected)
                {
                    id = int.Parse(permiso.Value);
                    var context = _context.Permisos.Where(p => p.Id == id).SingleOrDefault();
                    permisos.Add(context);
                }
            }

            try
            {
                role.Permisos = permisos;
                _context.Roles.Add(role);
                _context.SaveChanges();

            }
            catch (Exception ex) { }
            
            return RedirectToAction("Index");
        }

        public ActionResult EditarRol(string id)
        {
            if (id == "c2625e46-98d0-42ee-9aec-d38a408ee62c")
                return RedirectToAction("Index");

            var thisRole = _context.Roles
                .Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase))
                .FirstOrDefault();

            List<SelectListItem> listPermisos = new List<SelectListItem>();
            var permisos = _context.Permisos.ToList();
            var permisosRoles = _context.Permisos.Where(p => p.Roles.Any(r => r.Id == id)).ToList();
            bool bandera = false;
            if (thisRole == null)
                return RedirectToAction("Index");

            foreach (var item in permisos)
            {
                foreach (var permiso in permisosRoles)
                {
                    if(item.Id == permiso.Id)
                    {
                        bandera = true;
                        listPermisos.Add(new SelectListItem
                        {
                            Value = permiso.Id.ToString(),
                            Text = permiso.Descripcion,
                            Selected = true
                        });
                    }
                }
                if (!bandera)
                {
                    listPermisos.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.Descripcion,
                        Selected = false
                    });                    
                }
                bandera = false;
            }

            var viewModel = new RolViewModel((ApplicationRole)thisRole, listPermisos);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarRol(RolViewModel rol)
        {
            if (!ModelState.IsValid)
                return View(rol);

            var rolExistente = _context.Roles.SingleOrDefault(r => r.Name == rol.OriginalRoleName);
            
            ApplicationRole role = (ApplicationRole)rolExistente;
            _context.Entry(role).Collection(r => r.Permisos).Load();

            if (rolExistente == null)
                return HttpNotFound();

            List<Permisos> permisos = new List<Permisos>();
            foreach (var permiso in rol.Permisos)
            {
                if (permiso.Selected)
                {
                    permisos.Add(new Permisos
                    {
                        Id = int.Parse(permiso.Value),
                        Descripcion = permiso.Text
                    });
                }                
            }

            var permisosAgregados = permisos.Where(p => !role.Permisos.Any(p2 => p2.Id == p.Id)).ToList();
            var permisosEliminados = role.Permisos.Where(p => !permisos.Any(p2 => p2.Id == p.Id)).ToList();

            foreach (var item in permisosAgregados)
            {
                if (_context.Entry(item).State == EntityState.Detached)
                    _context.Permisos.Attach(item);

                role.Permisos.Add(item);
            }

            if (permisosEliminados.Count > 0)
                permisosEliminados.ForEach(c => role.Permisos.Remove(c));

            role.Name = rol.Name;
            role.Descripcion = rol.Descripcion;
            
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