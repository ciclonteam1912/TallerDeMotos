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

        [StringLength(20)]
        [Display(Name = "País de Origen")]
        public string PaisDeOrigen { get; set; }
        //public string ImagenMarca { get; set; }

        public Producto Producto { get; set; }

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
            Modelos = new HashSet<Modelo>();
        }

        public Marca(Marca marca)
        {
            Id = marca.Id;
            Nombre = marca.Nombre;
            Representante = marca.Representante;
            PaisDeOrigen = marca.PaisDeOrigen;
            Modelos = new HashSet<Modelo>();
        }
    }
}