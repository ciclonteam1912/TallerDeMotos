using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class CajaViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Display(Name = "Sucursal")]
        public int SucursalId { get; set; }

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
            SucursalId = caja.SucursalId;
        }
    }
}