using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Dtos
{
    public class CiudadDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}