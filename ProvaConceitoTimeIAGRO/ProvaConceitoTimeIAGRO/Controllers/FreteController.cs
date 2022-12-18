using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProvaConceitoTimeIAGRO.Models;
using ProvaConceitoTimeIAGRO.Repository;
using ProvaConceitoTimeIAGRO.Service;
using System.Net;
using System.Runtime.CompilerServices;

namespace ProvaConceitoTimeIAGRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreteController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(decimal))]
        public decimal Calcular(int idLivro)
        {
            ProdutoRepository produtoRepository = new ProdutoRepository();
            Produto? produto = produtoRepository.ObterUnico(idLivro);

            if (produto == null)
            {
                this.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                return -1;
            }

            var calcularValorDoFreteService = new CalcularValorDoFreteService();
            calcularValorDoFreteService.AddProduto(produto);


            var valorDoFrete = calcularValorDoFreteService.CalcularFreteDe20PorCento();


            return valorDoFrete;
        }
    }
}
