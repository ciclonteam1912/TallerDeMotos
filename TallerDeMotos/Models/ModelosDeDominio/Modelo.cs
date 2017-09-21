using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Modelo
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        public Marca Marca { get; set; }

        [Display(Name = "Marca")]
        public byte MarcaId { get; set; }
    }
}