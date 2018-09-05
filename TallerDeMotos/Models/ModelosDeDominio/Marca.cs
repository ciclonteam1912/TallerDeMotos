using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Models.AtributosDeValidacion;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Marca
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        [RestriccionUnicaEnMarca]
        [Remote("NombreExisteEnMarcas", "RemoteValidation", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Nombre de Marca ya existe.")]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Representante { get; set; }

        [Display(Name = "Fecha de Fabricación")]
        public DateTime? FechaDeFundacion { get; set; }
        //public string ImagenMarca { get; set; }

        public ICollection<Modelo> Modelos { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Marca" : "Nueva Marca";
            }
        }

        public Marca()
        {
            Modelos = new Collection<Modelo>();
        }

        public Marca(Marca marca)
        {
            Id = marca.Id;
            Nombre = marca.Nombre;
            Representante = marca.Representante;
            FechaDeFundacion = marca.FechaDeFundacion;
            Modelos = new Collection<Modelo>();
        }
    }
}