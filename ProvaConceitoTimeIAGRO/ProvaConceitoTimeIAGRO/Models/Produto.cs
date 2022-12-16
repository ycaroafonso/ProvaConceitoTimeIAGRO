namespace ProvaConceitoTimeIAGRO.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public Specifications specifications { get; set; }
    }
}
