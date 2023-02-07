using LocalizationExample.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            _logger = logger;
            _sharedResourceLocalizer = sharedResourceLocalizer;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var date = _sharedResourceLocalizer.GetString("lblDate").Value ?? "";
            var temperature = _sharedResourceLocalizer.GetString("lblTemperature").Value ?? "";

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = date + " : " + DateTime.Now.AddDays(index),
                TemperatureC = temperature + " : " + Random.Shared.Next(-20, 55).ToString(),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}