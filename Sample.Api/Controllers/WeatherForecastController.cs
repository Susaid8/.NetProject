using Microsoft.AspNetCore.Mvc;
using Sample.DataAccess;

namespace Sample.Api.Controllers
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
        private readonly ISampleRepository _repo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISampleRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var samples = await _repo.GetSamples();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public async Task Post(string message)
        {
            Console.WriteLine($"{message}");

            var entity = new SampleEntity()
            {
                SampleText= message,
                Created = DateTime.Now,
            };

            await _repo.AddSample(entity);
        }
    }
}