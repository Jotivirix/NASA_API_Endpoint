using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NASA_API_Endpoint.Models
{
	public class AsteroidModel
	{
		[JsonProperty(PropertyName = "nombre")]
        [Key]
		public string? Nombre { get; set; }

        [JsonProperty("diametro")]        
        public double? Diametro { get; set; }

        [JsonProperty("velocidad")]
        public double? Velocidad { get; set; }

        [JsonProperty("fecha")]
        public string? Fecha { get; set; }

        [JsonProperty("planeta")]
        public string? Planeta { get; set; }
    }
}

