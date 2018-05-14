namespace TallerDeMotos.Models
{
    public class RelacionFormaPagoYBanco
    {
        public int Id { get; set; }
        public byte FormaPagoId { get; set; }
        public int? BancoId { get; set; }
    }
}