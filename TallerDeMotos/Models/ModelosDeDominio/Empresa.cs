using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Empresa
    {
        public int Id{ get; set; }

        [Required]
        [StringLength(50)]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(50)]
        public string Ruc { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        public ICollection<Sucursal> Sucursales { get; set; }

        public Empresa()
        {
            Sucursales = new HashSet<Sucursal>();
        }
    }
}