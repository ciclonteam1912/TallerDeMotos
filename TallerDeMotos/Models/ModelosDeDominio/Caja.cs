using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public bool EstadoActivo { get; set; }                
    }
}