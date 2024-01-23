using Newtonsoft.Json;

namespace NASA_API_Endpoint.Models
{
	public class AsteroidModel
	{
		[JsonProperty("nombre")]
		public string Name { get; set; }

        [JsonProperty("diametro")]
        public double Diameter { get; set; }

        [JsonProperty("velocidad")]
        public double Speed { get; set; }

        [JsonProperty("fecha")]
        public string Date { get; set; }

        [JsonProperty("planeta")]
        public string Planet { get; set; }
    }
}

