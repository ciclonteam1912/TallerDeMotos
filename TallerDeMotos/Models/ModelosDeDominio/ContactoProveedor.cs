using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class ProveedorContacto
    {
        public int Id { get; set; }
        public Proveedor Proveedor { get; set; }
        public int ProveedorId { get; set; }
        public Contacto Contacto { get; set; }
        public int ContactoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}