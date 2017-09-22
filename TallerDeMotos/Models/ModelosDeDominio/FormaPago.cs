using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class FormaPago
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(255)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Forma de Pago" : "Agregar Forma de Pago";
            }
        }

        public FormaPago()
        {

        }

        public FormaPago(FormaPago formaPago)
        {
            Id = formaPago.Id;
            Nombre = formaPago.Nombre;
            Descripcion = formaPago.Descripcion;
        }
    }
}