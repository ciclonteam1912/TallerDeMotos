using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Dtos
{
    public class CargoDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }
    }
}