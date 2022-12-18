using ProvaConceitoTimeIAGRO.Models;
using ProvaConceitoTimeIAGRO.Models.Enums;

namespace ProvaConceitoTimeIAGRO.Service
{
    public class ProdutosFiltradosEOrdenadosService
    {
        private List<Produto> _produtos;
        public List<Produto> ProdutosFiltrados { get; set; }

        public ProdutosFiltradosEOrdenadosService(List<Produto> produtos)
        {
            ProdutosFiltrados = produtos;
        }


        /// <summary>
        /// Pesquisa em qualquer campo string do objeto
        /// </summary>
        /// <param name="pesquisa"></param>
        public void Filtrar(string pesquisa)
        {
            pesquisa = pesquisa.ToLower();

            ProdutosFiltrados = ProdutosFiltrados
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
                    ProdutosFiltrados = ProdutosFiltrados!.OrderBy(c => c.price).ToList();
                    break;
                case Ordenacao.desc:
                    ProdutosFiltrados = ProdutosFiltrados!.OrderByDescending(c => c.price).ToList();
                    break;
            }
        }



    }
}
