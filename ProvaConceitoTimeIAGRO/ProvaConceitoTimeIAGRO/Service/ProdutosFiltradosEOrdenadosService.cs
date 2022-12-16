using ProvaConceitoTimeIAGRO.Models;
using ProvaConceitoTimeIAGRO.Models.Enums;
using ProvaConceitoTimeIAGRO.Repository;

namespace ProvaConceitoTimeIAGRO.Service
{
    public class ProdutosFiltradosEOrdenadosService
    {
        private ProdutoRepository _produtoRepository;
        private List<Produto> _produtos;

        public ProdutosFiltradosEOrdenadosService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;

            _produtos = _produtoRepository.ObterTodosOsProdutos();
        }


        public List<Produto> ObterRetorno()
        {
            return _produtos;
        }


        /// <summary>
        /// Pesquisa em qualquer campo string do objeto
        /// </summary>
        /// <param name="pesquisa"></param>
        public void Filtrar(string pesquisa)
        {
            pesquisa = pesquisa.ToLower();

            _produtos = _produtos
                .Where(c =>
                    c.name.ToLower().Contains(pesquisa) ||
                    c.specifications.Originallypublished.ToLower().Contains(pesquisa) ||
                    c.specifications.Author.ToLower().Contains(pesquisa) ||
                    (c.specifications?.Illustrator?.Any(d => d.ToLower().Contains(pesquisa)) ?? true) ||
                    (c.specifications?.Genres?.Any(d => d.ToLower().Contains(pesquisa)) ?? true)
                    )
                .ToList();
        }



        public void OrdenarPorPrice(Ordenacao ordenacao = Ordenacao.asc)
        {
            switch (ordenacao)
            {
                case Ordenacao.asc:
                    _produtos = _produtos!.OrderBy(c => c.price).ToList();
                    break;
                case Ordenacao.desc:
                    _produtos = _produtos!.OrderByDescending(c => c.price).ToList();
                    break;
            }
        }



    }
}
