using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trading.Entities.Definitions;
using Trading.Operations.Implementation.CoinBasePro;
using Trading.Operations.Implementation.KuCoin;
using System.Diagnostics;

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
            try
            {
                CoinBaseExchange coinBase = new CoinBaseExchange(cliente.CreateClient("coinbase"));
                coinBase.SetAuthorization(new CoinBaseAuthorization
                {
                    Secret = "Y03CqYaz7etJ7jXenTB3duzskYgjrpleaAB9DAM+y4cmqK8VhsUKazZM3g6/5rR0ZmDVjRvYa/Xsd/XNtaE+lw==",
                    PassPhrase = "qpzyxsuh2x",
                    Key = "0dcc6b92f4b00953ab696b5b2695032a"
                });

                List<CoinBaseAccount> contas = await coinBase.GetAccounts();

                while (true)
                {
                    CoinBaseTicker ticker = await coinBase.GetTicker(new CoinBaseProduct { Id = "BTC-USD" });
                    Debug.WriteLine("Ask: " + ticker.Ask);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
