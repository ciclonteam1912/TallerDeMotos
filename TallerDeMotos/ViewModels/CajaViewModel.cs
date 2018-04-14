using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class CajaViewModel
    {
        public IEnumerable<ApplicationUser> Usuarios { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public bool EstadoActivo { get; set; }

        [Required]
        [Display(Name = "Asignar empleado a una Caja")]
        public string UsuarioId { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Caja" : "Nueva Caja";
            }
        }

        public CajaViewModel()
        {

        }

        public CajaViewModel(Caja caja)
        {
            Id = caja.Id;
            Nombre = caja.Nombre;
            UsuarioId = caja.UsuarioId;
            EstadoActivo = caja.EstadoActivo;
        }
    }
}