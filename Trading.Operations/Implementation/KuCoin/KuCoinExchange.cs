using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trading.Entities.Definitions;
using Trading.Operations.Definitions;

namespace Trading.Operations.Implementation.KuCoin
{
    public sealed class KuCoinExchange : BaseExchange, IExchange
    {
        /// <summary>
        /// Inicializa uma instancia de <see cref="KuCoinExchange"/>, fazendo a injeção de dependencia de HttpClient.
        /// </summary>
        /// <param name="httpClient">Uma instancia de <see cref="HttpClient"/> para ser usada nas requisições</param>
        public KuCoinExchange(HttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Armazena as informações de Autorização necessarias para realizar todas as transações disponiveis que não são publicas
        /// </summary>
        public IAuthorization Authorization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Cancela uma ordem de compra
        /// </summary>
        /// <param name="order">Ordem a ser cancelada</param>
        /// <returns>Um <see cref="bool"/> dizendo se a ordem foi cancelada ou não</returns>
        public bool CancelOrder(IOrder order)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cria uma ordem de compra
        /// </summary>
        /// <returns>
        /// Um objeto <see cref="IOrder" /> com o id da ordem
        /// </returns>
        public IOrder CreateOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Busca as informações de valores de todas as moedas no Exchange
        /// </summary>
        /// <returns>Uma <see cref="Task<List<>>"/> de moedas</returns>
        public async Task<List<BaseCurrency>> GetAllTickers()
        {
            try
            {
                HttpResponseMessage resposta = await HTTPClient.GetAsync("/api/v1/market/allTickers");

                JObject json = JObject.Parse(await resposta.Content.ReadAsStringAsync());

                List<KuCoinCurrency> teste = json.GetValue("data").SelectToken("ticker").ToObject<List<KuCoinCurrency>>(); // remover depois de testar

                return json.GetValue("ticker").ToObject<List<BaseCurrency>>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca todos os assets disponiveis em conta do usuário
        /// </summary>
        /// <returns>
        /// Um objeto <see cref="IBalance" /> com o balanço da conta
        /// </returns>
        public IBalance GetBalance()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Busca as informações de valores de uma moeda especifica no Exchange
        /// </summary>
        /// <param name="currency">Um objeto <see cref="BaseCurrency" /> com os dados da moeda a ser buscada as informações</param>
        /// <returns>
        /// Um objeto <see cref="BaseCurrency" /> com os dados da moeda
        /// </returns>
        public BaseCurrency GetTicker(BaseCurrency currency)
        {
            throw new NotImplementedException();
        }
    }
}
