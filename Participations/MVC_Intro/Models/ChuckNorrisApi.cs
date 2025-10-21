using System.Text.Json.Serialization;

namespace MVC_Intro.Models
{
    public class ChuckNorrisApi
    {
        [JsonPropertyName("value")]
        public string value { get; set; }

    }
}
