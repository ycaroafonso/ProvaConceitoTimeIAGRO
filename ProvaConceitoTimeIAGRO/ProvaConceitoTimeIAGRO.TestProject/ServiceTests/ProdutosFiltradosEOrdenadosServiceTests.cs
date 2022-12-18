using ProvaConceitoTimeIAGRO.Models;
using ProvaConceitoTimeIAGRO.Repository;
using ProvaConceitoTimeIAGRO.Service;

namespace ProvaConceitoTimeIAGRO.TestProject.ServiceTests
{
    public class ProdutosFiltradosEOrdenadosServiceTests
    {
        private ProdutosFiltradosEOrdenadosService _produtosFiltradosEOrdenadosService;

        [SetUp]
        public void Setup()
        {
            var produtoRepository = new ProdutoRepository();
            List<Produto> produtos = produtoRepository.ObterTodosOsProdutos();

            _produtosFiltradosEOrdenadosService = new ProdutosFiltradosEOrdenadosService(produtos);
        }




        //[TestCase(6.15M, Models.Enums.Ordenacao.asc)]
        [TestCase(Models.Enums.Ordenacao.asc, ExpectedResult = 6.15, TestName = "Ordenação ASC")]
        [TestCase(Models.Enums.Ordenacao.desc, ExpectedResult = 11.15, TestName = "Ordenação DESC")]
        public decimal TestarOrdenacao(Models.Enums.Ordenacao ordenacao)
        {
            // Arrange 

            // Act
            _produtosFiltradosEOrdenadosService.OrdenarPorPrice(ordenacao);


            //// Assert
            return _produtosFiltradosEOrdenadosService.ProdutosFiltrados[0].price;
        }
    }
}
