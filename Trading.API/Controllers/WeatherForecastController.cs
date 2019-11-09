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
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Trading.Operations.ExchangeEndpoints;
using Microsoft.Extensions.Options;

namespace Trading.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private CoinBaseProEndpoints EndPoints {get;set;}

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory cliente, IOptions<CoinBaseProEndpoints> endpoints)
        {
            _logger = logger;
            EndPoints = endpoints.Value;

            Teste(cliente);
        }

        public async Task Teste(IHttpClientFactory cliente)
        {
            try
            {
                CoinBaseExchange coinBase = new CoinBaseExchange(cliente.CreateClient("coinbase"), EndPoints);
                coinBase.SetAuthorization(new CoinBaseAuthorization
                {
                    Secret = "Y03CqYaz7etJ7jXenTB3duzskYgjrpleaAB9DAM+y4cmqK8VhsUKazZM3g6/5rR0ZmDVjRvYa/Xsd/XNtaE+lw==",
                    PassPhrase = "qpzyxsuh2x",
                    Key = "0dcc6b92f4b00953ab696b5b2695032a"
                });

                //List<CoinBaseAccount> contas = await coinBase.GetAccounts();

                //List<CoinBaseBalance> balanco = new List<CoinBaseBalance>();

                //foreach (CoinBaseAccount conta in contas)
                //{
                //    balanco.Add(await coinBase.GetBalance(conta));
                //}

                //foreach (CoinBaseAccount conta in contas)
                //{
                //    Debug.WriteLine("Id: " + conta.Id + "|Profile Id: " + conta.Profile_id + "|Currency: " + conta.Currency + "|Av: " + conta.Available);
                //}

                List<CoinBaseProduct> products = await coinBase.GetAllProducts();

                products.ForEach(p => Debug.WriteLine("Id: " + p.Id));

                //CoinBaseOrder ordem = new CoinBaseOrder
                //{
                //    Tipo = OrderType.Market,
                //    Lado = OrderSide.Sell,
                //    ProductId = "BTC-USD",
                //    Size = 0.01058207m
                //};

                //ordem = await coinBase.CreateOrder(ordem);


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
