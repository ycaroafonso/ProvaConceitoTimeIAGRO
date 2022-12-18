using ProvaConceitoTimeIAGRO.Service;

namespace ProvaConceitoTimeIAGRO.TestProject.ServiceTests
{
    public class CalcularValorDoFreteServiceTests
    {
        private CalcularValorDoFreteService _calcularValorDoFreteService;

        [SetUp]
        public void Setup()
        {
            _calcularValorDoFreteService = new CalcularValorDoFreteService();
        }




        [Test]
        public void Com1Produto()
        {

            // Arrange 
            _calcularValorDoFreteService.AddProduto(new Models.Produto
            {
                price = 10,
            });
            decimal valorFreteEsperado = 2M;


            // Act
            decimal valorFreteCalculado = _calcularValorDoFreteService.CalcularFreteDe20PorCento();


            // Assert
            Assert.That(valorFreteCalculado, Is.EqualTo(valorFreteEsperado));

        }




        [Test]
        public void Com2Produto()
        {
            var calcularValorDoFreteService = new CalcularValorDoFreteService();

            // Arrange 
            calcularValorDoFreteService.AddProduto(new Models.Produto
            {
                price = 10,
            });
            calcularValorDoFreteService.AddProduto(new Models.Produto
            {
                price = 13,
            });
            decimal valorFreteEsperado = 4.6M;


            // Act
            decimal valorFreteCalculado = calcularValorDoFreteService.CalcularFreteDe20PorCento();


            // Assert
            Assert.That(valorFreteCalculado, Is.EqualTo(valorFreteEsperado));

        }
    }
}