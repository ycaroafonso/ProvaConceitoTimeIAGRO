namespace ProvaConceitoTimeIAGRO.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public Specifications? specifications { get; set; }
    }
}
