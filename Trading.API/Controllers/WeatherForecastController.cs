using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trading.Entities.Definitions;
using Trading.Operations.Implementation.KuCoin;

namespace Trading.API.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory cliente)
        {
            _logger = logger;
            Teste(cliente);
        }

        public async Task Teste(IHttpClientFactory cliente)
        {
            KuCoinExchange teste = new KuCoinExchange(cliente.CreateClient("kucoin"), new KuCoinAuthorization("5dacaa7c1d70990008a7e8f0", "oloquinhomeu") 
            { 
                Secret = "whatever"
            });

            List<BaseAccount> t = await teste.GetAccounts();

            string g = "";
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
