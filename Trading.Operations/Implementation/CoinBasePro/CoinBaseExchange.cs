using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Entities.Definitions;
using Trading.Operations.Definitions;
using Trading.Operations.Exceptions;

namespace Trading.Operations.Implementation.CoinBasePro
{
    public sealed class CoinBaseExchange : BaseExchange, 
        IExchange<CoinBaseAuthorization, CoinBaseProduct, CoinBaseBalance, CoinBaseAccount, CoinBaseTicker>
    {
        public CoinBaseExchange(HttpClient httpClient) : base(httpClient) { }

        public CoinBaseAuthorization Authorization { get; set; }

        public bool CancelOrder(IOrder order)
        {
            throw new NotImplementedException();
        }

        public IOrder CreateOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CoinBaseProduct>> GetAllProducts()
        {
            try
            {
                HttpResponseMessage resposta = await HTTPClient.GetAsync("/products");
                string Conteudo = await resposta.Content.ReadAsStringAsync();

                if (resposta.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<CoinBaseProduct>>(Conteudo);
                }
                else
                {
                    throw new Exception(Conteudo);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CoinBaseBalance GetBalance()
        {
            throw new NotImplementedException();
        }

        public async Task<CoinBaseTicker> GetTicker(CoinBaseProduct currency)
        {
            try
            {
                HttpResponseMessage resposta = await HTTPClient.GetAsync("/products/" + currency.Id + "/ticker");
                string Conteudo = await resposta.Content.ReadAsStringAsync();

                if (resposta.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<CoinBaseTicker>(Conteudo);
                }
                else
                {
                    throw new Exception(Conteudo);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Seta a autorização ja buscando o TImeStamp automaticamente
        /// </summary>
        public void SetAuthorization(CoinBaseAuthorization authorization)
        {
            Authorization = authorization;
            Authorization.TimeStamp = GetTimeFromServer();
        }

        private HttpRequestMessage GetHeaders(HttpMethod method, string url, string body = null)
        {
            using (HttpRequestMessage requisicao = new HttpRequestMessage(method, HTTPClient.BaseAddress + url))
            {
                requisicao.Headers.Add("CB-ACCESS-KEY", Authorization.Key);
                requisicao.Headers.Add("CB-ACCESS-SIGN", Authorization.GetSign(url, method.Method, body));
                requisicao.Headers.Add("CB-ACCESS-TIMESTAMP", Authorization.TimeStamp);
                requisicao.Headers.Add("CB-ACCESS-PASSPHRASE", Authorization.PassPhrase);

                return requisicao;
            }
        }

        public async Task<List<CoinBaseAccount>> GetAccounts()
        {
            try
            {
                if (!Authorization.isValid())
                {
                    throw new AuthorizationException("Para essa operação, são necessarias as informações de Authorização do usuario");
                }

                using HttpRequestMessage requisicao = GetHeaders(HttpMethod.Get, "/accounts");
                HttpResponseMessage resposta = await HTTPClient.SendAsync(requisicao);

                string Conteudo = await resposta.Content.ReadAsStringAsync();

                if (resposta.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<CoinBaseAccount>>(Conteudo);
                }
                else
                {
                    throw new Exception(Conteudo);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GetTimeFromServer()
        {
            try
            {
                Task<HttpResponseMessage> tarefaRequisicao = Task.Run(() => HTTPClient.GetAsync("/time"));
                tarefaRequisicao.Wait();

                Task<string> tarefaLeitura = Task.Run(() => tarefaRequisicao.Result.Content.ReadAsStringAsync());
                tarefaLeitura.Wait();

                if (tarefaRequisicao.Result.IsSuccessStatusCode)
                {
                    return JObject.Parse(tarefaLeitura.Result).GetValue("epoch").ToObject<string>();
                }
                else
                {
                    throw new Exception(tarefaLeitura.Result);
                }                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
