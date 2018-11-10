using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.AtributosDeValidacion;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Caja
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public Sucursal Sucursal { get; set; }

        [Display(Name = "Sucursal")]
        public int SucursalId { get; set; }

        public ICollection<AperturaCierreCaja> AperturaCierres { get; set; }
        public ICollection<Talonario> Talonarios { get; set; }

        public Caja()
        {
            AperturaCierres = new HashSet<AperturaCierreCaja>();
            Talonarios = new HashSet<Talonario>();
        }
    }
}