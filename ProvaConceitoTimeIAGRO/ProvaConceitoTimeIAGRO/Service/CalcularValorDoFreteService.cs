using ProvaConceitoTimeIAGRO.Models;
using ProvaConceitoTimeIAGRO.Repository;

namespace ProvaConceitoTimeIAGRO.Service
{
    public class CalcularValorDoFreteService
    {
        private ProdutoRepository _produtoRepository;
        private List<Produto> _produtos;
        private Produto? _produto;

        public CalcularValorDoFreteService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;

            _produtos = _produtoRepository.ObterTodosOsProdutos();
        }

        public void SelecionarProduto(int id)
        {
            _produto = _produtos.Where(c => c.id == id).SingleOrDefault();
        }

        public decimal CalcularFreteDe20PorCento()
        {
            return _produto!.price * 0.20M;
        }
    }
}
