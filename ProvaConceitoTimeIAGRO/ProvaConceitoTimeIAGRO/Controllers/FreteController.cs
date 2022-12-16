using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaConceitoTimeIAGRO.Repository;
using ProvaConceitoTimeIAGRO.Service;

namespace ProvaConceitoTimeIAGRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreteController : ControllerBase
    {
        [HttpGet]
        public decimal Calcular(int idLivro)
        {
            var produtoRepository = new ProdutoRepository();
            var calcularValorDoFreteService = new CalcularValorDoFreteService(produtoRepository);

            calcularValorDoFreteService.SelecionarProduto(idLivro);
            var valorDoFrete = calcularValorDoFreteService.CalcularFreteDe20PorCento();

            return valorDoFrete;
        }
    }
}
