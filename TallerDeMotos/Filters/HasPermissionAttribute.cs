using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Models;

namespace TallerDeMotos.Filters
{
    public class HasPermissionAttribute : ActionFilterAttribute
    {
        private string _permission;
        private ApplicationDbContext _context = new ApplicationDbContext();
        private ConexionBD conexionBD = new ConexionBD();

        public HasPermissionAttribute(string permission)
        {
            this._permission = permission;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!conexionBD.CHECK_IF_USER_OR_ROLE_HAS_PERMISSION(_permission) && !HttpContext.Current.User.Identity.Name.Equals("admin"))
            {
                // If this user does not have the required permission then redirect to login page
                var url = new UrlHelper(filterContext.RequestContext);
                var loginUrl = "~/error/accesodenegado";
                filterContext.RequestContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }        
    }
}