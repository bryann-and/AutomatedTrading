using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trading.Entities.Definitions;
using Trading.Operations.Implementation.CoinBasePro;
using Trading.Operations.Implementation.KuCoin;

namespace Trading.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory cliente)
        {
            _logger = logger;
            Teste(cliente);
        }

        public async Task Teste(IHttpClientFactory cliente)
        {
            CoinBaseExchange coinBase = new CoinBaseExchange(cliente.CreateClient("coinbase"));

            List<CoinBaseProduct> oloko = await coinBase.GetAllTickers();

            if (oloko.Count >= 0)
            {

            }
        }
    }
}
