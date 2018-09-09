using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models;

namespace TallerDeMotos.ViewModels
{
    public class RolViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        public string OriginalRoleName { get; set; }

        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public RolViewModel()
        {

        }

        public RolViewModel(ApplicationRole rol)
        {
            Name = rol.Name;
            OriginalRoleName = rol.Name;
            Descripcion = rol.Descripcion;
        }
    }
}