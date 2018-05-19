using System;

namespace TallerDeMotos.Dtos
{
    public class AperturaCierreDto
    {
        public int Id { get; set; }
        public CajaDto Caja { get; set; }
        public int CajaId { get; set; }
        public DateTime Fecha { get; set; }
        public long SaldoInicial { get; set; }
        public long? SaldoFinal { get; set; }
        public bool EstaAbierta { get; set; }
    }
}