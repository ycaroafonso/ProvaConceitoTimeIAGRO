using ProvaConceitoTimeIAGRO.Models;

namespace ProvaConceitoTimeIAGRO.Service
{
    public class CalcularValorDoFreteService
    {
        private decimal _total = 0;

        public CalcularValorDoFreteService()
        {
        }


        public void AddProduto(Produto produto)
        {
            _total += produto.price;
        }


        public decimal CalcularFreteDe20PorCento()
        {
            return _total * 0.2M;
        }
    }
}
