using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Permisos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        public ICollection<ApplicationRole> Roles { get; set; }

        public Permisos()
        {
            Roles = new HashSet<ApplicationRole>();
        }
    }
}