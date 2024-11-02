using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AngularCOMP584.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Action", "Platformer", "Role-Playing Games", "Puzzle", "Shooter", "Sports", "Fighting", "Adventure", "Racing", "Survival"
        };

        private static readonly string[] Games = new[]
       {
            "Grand Theft Auto V", "Super Mario", "Baldurs gate", "Tetris", "Call of Duty", "Madden", "Street Fighter", "Elden Ring", "Forza", "DayZ"
        };

        private static readonly string[] ReleaseDates = new[]
       {
            "2013-09-17", "1985-09-13", "2023-08-03", "1984-06-06", "2003-10-29",
            "2022-08-19", "1987-08-30", "2022-02-25", "2021-10-05", "2018-12-13"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                //Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Game = Games[Random.Shared.Next(Games.Length)],
                //TemperatureC = Random.Shared.Next(-20, 55),
                ReleasedDate = DateOnly.ParseExact(ReleaseDates[Random.Shared.Next(ReleaseDates.Length)], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                CurrentPlayers = Random.Shared.Next(1000, 1000000),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
