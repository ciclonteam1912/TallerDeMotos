﻿namespace TallerDeMotos.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string Marca { get; set; }

        public int PrecioCosto { get; set; }

        public int PrecioVenta { get; set; }

        public int? ExistenciaInicial { get; set; }

        public int? ExistenciaActual { get; set; }

        public int? ExistenciaMinima { get; set; }

        public byte Iva { get; set; }
    }
}