using ProvaConceitoTimeIAGRO.Repository;
using ProvaConceitoTimeIAGRO.Service;

namespace ProvaConceitoTimeIAGRO.TestProject.Repository
{
    public class ProdutoRepositoryTests
    {
        private ProdutoRepository _produtoRepository;

        [SetUp]
        public void Setup()
        {
            _produtoRepository = new ProdutoRepository();
        }




        [Test]
        public void ObterUnico()
        {

            // Arrange 


            // Act
            var produto = _produtoRepository.ObterUnico(4);


            // Assert
            Assert.That(produto, Is.Not.Null);
            Assert.That(produto.id, Is.EqualTo(4));
            Assert.That(produto.name, Is.EqualTo("Fantastic Beasts and Where to Find Them: The Original Screenplay"));
        }



        [Test]
        public void ObterTodosOsProdutos()
        {

            // Arrange 


            // Act
            var lista = _produtoRepository.ObterTodosOsProdutos();
            int qtdeEsperada = 5;


            // Assert
            Assert.That(qtdeEsperada, Is.EqualTo(lista.Count));

        }
    }
}
