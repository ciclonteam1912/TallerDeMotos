using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class ModeloViewModel
    {
        #region Listas
        public IEnumerable<Marca> Marcas { get; set; }
        public IEnumerable<TipoMotor> TiposMotores { get; set; }
        public IEnumerable<Cilindrada> Cilindradas { get; set; }
        #endregion

        #region Propiedades
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        [Remote("NombreExisteEnModelos", "RemoteValidation", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Nombre del Modelo ya existe.")]
        public string Nombre { get; set; }

        [Display(Name = "Marca")]
        public byte MarcaId { get; set; }

        [Display(Name = "Cilindrada")]
        public byte CilindradaId { get; set; }

        [Display(Name = "Tipo de Motor")]
        public byte TipoMotorId { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Modelo" : "Nuevo Modelo";
            }
        }
        #endregion

        #region Constructores
        public ModeloViewModel()
        {

        }

        public ModeloViewModel(Modelo modelo)
        {
            Id = modelo.Id;
            Nombre = modelo.Nombre;
            MarcaId = modelo.MarcaId;
            CilindradaId = modelo.CilindradaId;
            TipoMotorId = modelo.TipoMotorId;
        }
        #endregion
    }
}