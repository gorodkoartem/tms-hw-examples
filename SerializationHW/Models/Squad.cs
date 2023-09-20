using System.Text.Json.Serialization;

namespace SerializationHW.Models
{
    [Serializable]
    public class Squad
    {
        [JsonPropertyName("squadName")]
        public string Name { get; set; }

        [JsonPropertyName("homeTown")]
        public string HomeTown { get; set; }

        [JsonPropertyName("formed")]
        public int FormedYear { get; set; }

        [JsonPropertyName("secretBase")]
        public string SecretBase { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("members")]
        public Hero[] Members { get; set; }
    }
}
