using System;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace NASA_API_Endpoint.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/asteroids")]
public class AsteroidsController : ControllerBase
{
    string API_KEY = "zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";

    public AsteroidsController()
    {
    }


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

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();



                //reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                return Ok(apiResponse);
            }
        }
    }
}


