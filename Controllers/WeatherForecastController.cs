using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using aspnet_server.Models;

namespace aspnet_server.Controllers;

[ApiController]
[Route("/api/weatherforecast")]
[EnableCors("ReactPolicy")]
public class WeatherForecastController : ControllerBase {
    private static readonly string[] Summaries = new[] {
        "Freezing", "Cool", "Warm", "Hot", "Sweltering", "Scorching"
    };
    private readonly ILogger<WeatherForecastController> logger;
    public WeatherForecastController(ILogger<WeatherForecastController> logger) {
        this.logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get() {
        return Enumerable.Range(1, 5).Select((index) => 
            new WeatherForecast {
                Id = index,
                Date = DateTime.Now.AddMonths(index)
                    .AddHours(index)
                    .AddDays(index)
                    .AddMinutes(index)
                    .AddSeconds(index),
                TemperatureC = Random.Shared.Next(-20, 35),
                Summary = Summaries[Random.Shared.Next(Summaries.Length - 1)]
            }
        ).ToList();
    }

    [HttpGet("{id}")]
    public WeatherForecast GetById(int id) {
        return new WeatherForecast {
            Id = id,
            Date = DateTime.Now,
            TemperatureC = Random.Shared.Next(0, 35),
            Summary = "Mild"
        };
    }
}
