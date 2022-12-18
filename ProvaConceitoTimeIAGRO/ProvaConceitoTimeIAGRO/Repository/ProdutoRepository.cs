using Newtonsoft.Json;
using ProvaConceitoTimeIAGRO.Models;

namespace ProvaConceitoTimeIAGRO.Repository
{
    public class ProdutoRepository
    {
        public List<Produto> ObterTodosOsProdutos()
        {

            var arquivoJsonDeProdutos = File.ReadAllText(Path.Combine("Data", "books.json"));
            var produtos = JsonConvert.DeserializeObject<List<Produto>>(arquivoJsonDeProdutos);

            return produtos!;

        }

        public Produto? ObterUnico(int idProduto)
        {
            return ObterTodosOsProdutos().SingleOrDefault(c => c.id == idProduto);
        }
    }
}
