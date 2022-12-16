using Newtonsoft.Json;

namespace ProvaConceitoTimeIAGRO.Models
{
    public class Specifications
    {
        [JsonProperty("Originally published")]
        public string Originallypublished { get; set; }
        public string Author { get; set; }

        [JsonProperty("Page count")]
        public int Pagecount { get; set; }
        public List<string>? Illustrator { get; set; }
        public List<string>? Genres { get; set; }
    }
}
