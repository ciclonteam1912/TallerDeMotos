using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class ServicioBasico
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
                return Id != 0 ? "Editar Servicio Básico" : "Agregar Servicio Básico";
            }
        }

        public ServicioBasico()
        {

        }

        public ServicioBasico(ServicioBasico servicioBasico)
        {
            Id = servicioBasico.Id;
            Nombre = servicioBasico.Nombre;
            Descripcion = servicioBasico.Descripcion;
        }
    }
}