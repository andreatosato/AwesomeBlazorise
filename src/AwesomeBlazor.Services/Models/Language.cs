using System.Text.Json.Serialization;

namespace AwesomeBlazor.Services.Models
{
    public class Language
    {
        [JsonPropertyName("iso_639_1")]
        public string IsoFormat { get; set; }

        [JsonPropertyName("english_name")]
        public string EnglishName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
