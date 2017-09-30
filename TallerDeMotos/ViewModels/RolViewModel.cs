using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.ViewModels
{
    public class RolViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        public string OriginalRoleName { get; set; }

        public RolViewModel()
        {

        }

        public RolViewModel(IdentityRole rol)
        {
            Name = rol.Name;
            OriginalRoleName = rol.Name;
        }
    }
}