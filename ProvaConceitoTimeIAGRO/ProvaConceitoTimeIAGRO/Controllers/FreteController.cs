using Microsoft.AspNetCore.Mvc;
using ProvaConceitoTimeIAGRO.Models;
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
            ProdutoRepository produtoRepository = new ProdutoRepository();
            Produto produto = produtoRepository.ObterUnico(idLivro);


            var calcularValorDoFreteService = new CalcularValorDoFreteService();
            calcularValorDoFreteService.AddProduto(produto);


            var valorDoFrete = calcularValorDoFreteService.CalcularFreteDe20PorCento();


            return valorDoFrete;
        }
    }
}
