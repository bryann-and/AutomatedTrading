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
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory cliente)
        {
            _logger = logger;
            Teste(cliente);
        }

        public async Task Teste(IHttpClientFactory cliente)
        {
            KuCoinExchange teste = new KuCoinExchange(cliente.CreateClient("kucoin"));
            teste.SetAuthorization(new KuCoinAuthorization
            {
                Key = "",
                PassPhrase = "",
                Secret = ""
            });


            List<KuCoinCurrency> pairs = await teste.GetAllTickers();

            List<KuCoinAccount> t = await teste.GetAccounts();

            string g = "";
        }
    }
}
