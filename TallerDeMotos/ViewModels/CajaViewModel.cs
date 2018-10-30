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

        [Required]
        [Display(Name = "Asignar empleado a una Caja")]
        public string UsuarioId { get; set; }

        [Display(Name = "Sucursal")]
        public int SucursalId { get; set; }

        public bool EstadoCaja { get; set; }

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
            SucursalId = caja.SucursalId;
            EstadoCaja = caja.EstadoCaja;
        }
    }
}