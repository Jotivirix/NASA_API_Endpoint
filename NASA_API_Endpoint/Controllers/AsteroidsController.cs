using System.Collections;
using Microsoft.AspNetCore.Mvc;
using NASA_API_Endpoint.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NASA_API_Endpoint.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/asteroids")]
public class AsteroidsController : ControllerBase
{
    string API_KEY = "zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";

    public AsteroidsController() { }

    [HttpGet]
    public async Task<IActionResult> Get(int days)
    {
        var responseMessage = new HttpResponseMessage();

        if (days < 1 || days > 7)
        {
            responseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
            responseMessage.ReasonPhrase = "The number of days should be a value between 1 and 7";
            return BadRequest(responseMessage);
        }

        string startDate = DateTime.UtcNow.Date.ToString("yyyy-MM-dd");
        string endDate = DateTime.UtcNow.Date.AddDays(Convert.ToDouble(days)).ToString("yyyy-MM-dd");

        string url = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={startDate}&end_date={endDate}&api_key={API_KEY}";

        List<AsteroidModel> validData = new List<AsteroidModel>();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                var jObjectResult = JObject.Parse(apiResponse)!["near_earth_objects"]!.Children().Children().Children();

                foreach (var asteroid in jObjectResult)
                {
                    var isValid = (bool)asteroid["is_potentially_hazardous_asteroid"]!;

                    if (isValid)
                    {
                        double diameter = (
                            (double)asteroid["estimated_diameter"]!["kilometers"]!["estimated_diameter_min"]! +
                            (double)asteroid["estimated_diameter"]!["kilometers"]!["estimated_diameter_max"]!
                        ) / 2.0;

                        //The item is hazardous. Build Object
                        AsteroidModel _asteroid = new AsteroidModel();
                        _asteroid.Name = asteroid["name"]!.ToString();
                        _asteroid.Diameter = diameter;
                        _asteroid.Speed = (double)asteroid["close_approach_data"]![0]!["relative_velocity"]!["kilometers_per_hour"]!;
                        _asteroid.Date = asteroid["close_approach_data"]![0]!["close_approach_date"]!.ToString();
                        _asteroid.Planet = asteroid["close_approach_data"]![0]!["orbiting_body"]!.ToString();

                        validData.Add(_asteroid);
                    }
                }



                var results = JsonConvert.SerializeObject(validData, Formatting.Indented);

                return Ok(validData);
            }
        }
    }
}


