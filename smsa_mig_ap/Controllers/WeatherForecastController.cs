using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smsa_mig_ap.Data;

namespace smsa_mig_ap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MigContext migContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MigContext migContext)
        {
            _logger = logger;
            this.migContext = migContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> get_products()
        {
            try
            {
                return Ok(await (from p in migContext.Product
                                 select p).ToListAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
