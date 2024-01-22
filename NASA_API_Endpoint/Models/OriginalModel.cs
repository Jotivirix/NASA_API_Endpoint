using System;
using Newtonsoft.Json;

namespace NASA_API_Endpoint.Models
{
	public class OriginalModel
	{
		[JsonProperty("links")]
		public dynamic links;

        [JsonProperty("element_count")]
        public dynamic element_count;

        [JsonProperty("near_earth_objects")]
        public dynamic near_earth_objects;
	}
}

