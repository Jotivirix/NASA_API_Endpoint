using System;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using NASA_API_Endpoint.Models;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace NASA_API_Endpoint.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/asteroids")]
public class AsteroidsController : ControllerBase
{
    string API_KEY = "zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";

    public AsteroidsController() {}

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

        ArrayList validData = new ArrayList();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                var jObjectResult = JObject.Parse(apiResponse)["near_earth_objects"];

                foreach (var day in jObjectResult!)
                {
                    //Iterate over each day trying to find any hazardous object
                    foreach (var resultsFromDay in day)
                    {
                        foreach (var hazardousObject in resultsFromDay)
                        {
                            //Here we have to search for the object.
                            var isValid = (bool)hazardousObject["is_potentially_hazardous_asteroid"]!;
                            if (isValid)
                            {
                                double diameter = ((double)hazardousObject["estimated_diameter"]!["kilometers"]!["estimated_diameter_min"]! +
                                    (double)hazardousObject["estimated_diameter"]!["kilometers"]!["estimated_diameter_max"]!) / 2;

                                //The item is hazardous. Build Object
                                AsteroidModel asteroid = new AsteroidModel();
                                asteroid.name = hazardousObject["name"]!.ToString();
                                asteroid.diameter = diameter;
                                asteroid.speed = (double)hazardousObject["close_approach_data"]![0]!["relative_velocity"]!["kilometers_per_hour"]!;
                                asteroid.date = hazardousObject["close_approach_data"]![0]!["close_approach_date"]!.ToString();
                                asteroid.planet = hazardousObject["close_approach_data"]![0]!["orbiting_body"]!.ToString();

                                validData.Add(asteroid);
                            }
                        }

                    }
                }

                return Ok(apiResponse);
            }
        }
    }
}


