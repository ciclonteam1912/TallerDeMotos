using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Dtos
{
    public class BancoDto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}