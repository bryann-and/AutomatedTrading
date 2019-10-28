using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trading.Entities.Definitions;
using Trading.Operations.Definitions;
using Trading.Operations.Exceptions;

namespace Trading.Operations.Implementation.KuCoin
{
    public sealed class KuCoinExchange : BaseExchange, IExchange<KuCoinAuthorization, KuCoinCurrency, KuCoinBalance, KuCoinAccount>
    {
        public KuCoinAuthorization Authorization { get; set; }

        /// <summary>
        /// Inicializa uma instancia de <see cref="KuCoinExchange"/>, fazendo a injeção de dependencia de HttpClient.
        /// </summary>
        /// <param name="httpClient">Uma instancia de <see cref="HttpClient"/> para ser usada nas requisições</param>
        public KuCoinExchange(HttpClient httpClient) : base(httpClient) { }

        public void SetAuthorization(KuCoinAuthorization authorization)
        {
            if (string.IsNullOrWhiteSpace(authorization.TimeStamp))
            {
                // Buscando o timestamp do servidor
                Task<string> tarefa = Task.Run(() => GetTimeFromServer());
                tarefa.Wait();
                authorization.TimeStamp = tarefa.Result;
            }

            Authorization = authorization;
        }

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
        /// Busca as contas disponiveis
        /// </summary>
        /// <returns>Uma <see cref="List<>"/> com as contas</returns>
        public async Task<List<KuCoinAccount>> GetAccounts()
        {
            try
            {
                if (Authorization is null || !Authorization.isValid())
                {
                    throw new AuthorizationException("Para essa operação, são necessarias as informações de Authorização do usuario");
                }

                using (HttpRequestMessage requisicao = new HttpRequestMessage())
                {
                    string url = "api/v1/accounts";

                    requisicao.RequestUri = new Uri(HTTPClient.BaseAddress + url);
                    requisicao.Method = HttpMethod.Get;

                    requisicao.Headers.Add("KC-API-KEY", Authorization.Key);
                    requisicao.Headers.Add("KC-API-SIGN", Authorization.GetSign(url, "GET"));
                    requisicao.Headers.Add("KC-API-TIMESTAMP", Authorization.TimeStamp);
                    requisicao.Headers.Add("KC-API-PASSPHRASE", Authorization.PassPhrase);

                    HttpResponseMessage resposta = await HTTPClient.SendAsync(requisicao);

                    return JsonConvert.DeserializeObject<List<KuCoinAccount>>(await resposta.Content.ReadAsStringAsync());
                }                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca as informações de valores de todas as moedas no Exchange
        /// </summary>
        /// <returns>Uma <see cref="Task<List<>>"/> de moedas</returns>
        public async Task<List<KuCoinCurrency>> GetAllTickers()
        {
            try
            {
                HttpResponseMessage resposta = await HTTPClient.GetAsync("/api/v1/market/allTickers");

                JObject json = JObject.Parse(await resposta.Content.ReadAsStringAsync());

                return json.GetValue("data").SelectToken("ticker").ToObject<List<KuCoinCurrency>>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca todos os assets disponiveis em todas as contas do usuário
        /// </summary>
        /// <returns>
        /// Um objeto <see cref="KuCoinBalance" /> com o balanço da conta
        /// </returns>
        public KuCoinBalance GetBalance()
        {
            throw new NotImplementedException("O KuCoin não oferece a possibilidade de buscar o balanço de uma maneira generica, a plataforma sempre pede o ID da conta. O mais proximo de um GetBalance() no KuCoin é o método GetAccounts()");
        }

        /// <summary>
        /// Busca todos os assets disponiveis em uma conta especifica
        /// </summary>
        /// <param name="account">A conta que se deseja buscar o balanço</param>
        /// <returns>
        /// Um objeto <see cref="KuCoinAccount" /> com o balanço da conta
        /// </returns>
        public async Task<KuCoinBalance> GetBalance(KuCoinAccount account)
        {
            try
            {
                if (Authorization is null || !Authorization.isValid())
                {
                    throw new AuthorizationException("Para essa operação, são necessarias as informações de Authorização do usuario");
                }

                HttpResponseMessage resposta = await HTTPClient.GetAsync("/api/v1/accounts/" + account.Id);

                return JsonConvert.DeserializeObject<KuCoinBalance>(await resposta.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca as informações de valores de uma moeda especifica no Exchange
        /// </summary>
        /// <param name="currency">Um objeto <see cref="KuCoinCurrency" /> com os dados da moeda a ser buscada as informações</param>
        /// <returns>
        /// Um objeto <see cref="KuCoinCurrency" /> com os dados da moeda
        /// </returns>
        public KuCoinCurrency GetTicker(KuCoinCurrency currency)
        {
            throw new NotImplementedException();
        }

        public async Task GetFiatPrice()
        {
            try
            {
                HttpResponseMessage resposta = await HTTPClient.GetAsync("/api/v1/prices");
                string teste = await resposta.Content.ReadAsStringAsync();
                teste = "q";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca o tempo na API KuCoin
        /// </summary>
        /// <returns>Uma string contento o tem po retornado pela API do KuCoin</returns>
        public async Task<string> GetTimeFromServer()
        {
            try
            {
                HttpResponseMessage resposta = await HTTPClient.GetAsync("/api/v1/timestamp");

                JObject json = JObject.Parse(await resposta.Content.ReadAsStringAsync());

                return json.GetValue("data").ToObject<string>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
