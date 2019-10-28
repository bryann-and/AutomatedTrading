using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Entities.Definitions;
using Trading.Operations.Definitions;

namespace Trading.Operations.Implementation.CoinBasePro
{
    public sealed class CoinBaseExchange : BaseExchange, IExchange<CoinBaseAuthorization, CoinBaseProduct, CoinBaseBalance, CoinBaseAccount>
    {
        public CoinBaseExchange(HttpClient httpClient) : base(httpClient) { }

        public CoinBaseAuthorization Authorization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CancelOrder(IOrder order)
        {
            throw new NotImplementedException();
        }

        public IOrder CreateOrder()
        {
            throw new NotImplementedException();
        }

        public Task<List<CoinBaseAccount>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CoinBaseProduct>> GetAllTickers()
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

        public Task<CoinBaseBalance> GetBalance(CoinBaseAccount account)
        {
            throw new NotImplementedException();
        }

        public CoinBaseProduct GetTicker(CoinBaseProduct currency)
        {
            throw new NotImplementedException();
        }

        public void SetAuthorization(CoinBaseAuthorization authorization)
        {
            throw new NotImplementedException();
        }

        private HttpRequestMessage GetHeaders(HttpMethod method, string url, string body)
        {
            HttpRequestMessage requisicao = new HttpRequestMessage(method, HTTPClient.BaseAddress + url);

            requisicao.Headers.Add("CB-ACCESS-KEY", Authorization.Key);
            requisicao.Headers.Add("CB-ACCESS-SIGN", Authorization.GetSign(url, method.Method, body));
            requisicao.Headers.Add("CB-ACCESS-TIMESTAMP", Authorization.TimeStamp);
            requisicao.Headers.Add("CB-ACCESS-PASSPHRASE", Authorization.PassPhrase);

            return requisicao;
        }
    }
}
