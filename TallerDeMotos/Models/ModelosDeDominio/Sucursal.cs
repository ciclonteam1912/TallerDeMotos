using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Sucursal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }

        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public Ciudad Ciudad { get; set; }
        public int CiudadId { get; set; }

        public string NombreCompleto {
            get
            {
                return Ciudad.Nombre + " - " + Direccion;
            }
        }

        public ICollection<Caja> Cajas { get; set; }

        public Sucursal()
        {
            Cajas = new HashSet<Caja>();
        }
    }
}