using System;
using Newtonsoft.Json;

namespace NASA_API_Endpoint.Models
{
	public class AsteroidModel
	{
		[JsonProperty("nombre")]
		public string name;

        [JsonProperty("diametro")]
        public double diameter;

        [JsonProperty("velocidad")]
        public double speed;

        [JsonProperty("fecha")]
        public string date;

        [JsonProperty("planeta")]
        public string planet;
    }
}

