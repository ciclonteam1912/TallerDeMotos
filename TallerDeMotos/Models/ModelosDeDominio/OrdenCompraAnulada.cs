using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class OrdenCompraAnulada
    {
        public int Id { get; set; }

        public OrdenCompra OrdenCompra { get; set; }

        public int OrdenCompraId { get; set; }

        [Required]
        [StringLength(2000)]
        public string MotivoAnulacion { get; set; }
    }
}