using Microsoft.AspNetCore.Mvc;
using ProvaConceitoTimeIAGRO.Models;
using ProvaConceitoTimeIAGRO.Models.Enums;
using ProvaConceitoTimeIAGRO.Repository;
using ProvaConceitoTimeIAGRO.Service;
using System.ComponentModel.DataAnnotations;

namespace ProvaConceitoTimeIAGRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="ordenacao">1 = asc; -1 = desc</param>
        /// <returns></returns>
        [HttpGet]
        public List<Produto> GetAll(string q = "", [Required] Ordenacao ordenacao = Ordenacao.asc)
        {
            var produtoRepository = new ProdutoRepository();
            var produtos = produtoRepository.ObterTodosOsProdutos();

            var produtosFiltradosEOrdenadosService = new ProdutosFiltradosEOrdenadosService(produtos);
            produtosFiltradosEOrdenadosService.Filtrar(q);
            produtosFiltradosEOrdenadosService.OrdenarPorPrice(ordenacao);

            return produtosFiltradosEOrdenadosService.ProdutosFiltrados;
        }
    }
}
