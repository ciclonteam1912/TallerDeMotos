using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

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
        public bool IsSelected { get; set; }
        public List<SelectListItem> Permisos { get; set; }

        public RolViewModel()
        {

        }

        public RolViewModel(ApplicationRole rol, List<SelectListItem> permisos)
        {
            Name = rol.Name;
            OriginalRoleName = rol.Name;
            Descripcion = rol.Descripcion;
            Permisos = permisos;          
        }
    }
}