using System;
using Newtonsoft.Json;

namespace NASA_API_Endpoint.Models
{
	public class NearEarthObject
	{
		[JsonProperty("is_potentially_hazardous_asteroid")]
		public string isHazardous;

        [JsonProperty("close_approach_data")]
        public string approachData;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("estimated_diameter")]
        public string estimated_diameter;

    }
}

