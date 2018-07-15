using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Caja
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public ApplicationUser Usuario { get; set; }

        [Required]
        public string UsuarioId { get; set; }

        public ICollection<AperturaCierreCaja> AperturaCierres { get; set; }
        public ICollection<Talonario> Talonarios { get; set; }

        public Caja()
        {
            AperturaCierres = new HashSet<AperturaCierreCaja>();
            Talonarios = new HashSet<Talonario>();
        }
    }
}