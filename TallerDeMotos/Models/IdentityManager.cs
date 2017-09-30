using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TallerDeMotos.Models
{
    public class IdentityManager
    {
        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public bool RoleExists(string name)
        {
            return roleManager.RoleExists(name);
        }
    }
}