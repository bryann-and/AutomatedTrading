﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trading.Operations.Definitions;
using Trading.Operations.Exceptions;

namespace Trading.Operations.Implementation.CoinBasePro
{
    public sealed class CoinBaseExchange : BaseExchange<CoinBaseAuthorization>, 
        IExchange<CoinBaseAuthorization, CoinBaseProduct, CoinBaseBalance, CoinBaseAccount, CoinBaseTicker, CoinBaseOrder>
    {
        public CoinBaseExchange(HttpClient httpClient) : base(httpClient) { }

        public bool CancelOrder(CoinBaseOrder order)
        {
            throw new NotImplementedException();
        }

        public async Task<CoinBaseOrder> CreateOrder(CoinBaseOrder order)
        {
            try
            {
                using (HttpRequestMessage requisicao = GetRequest(HttpMethod.Post, "/orders", order.ToJson()))
                {
                    HttpResponseMessage resposta = await HTTPClient.SendAsync(requisicao);
                    string resultado = await resposta.Content.ReadAsStringAsync();

                    if (resposta.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<CoinBaseOrder>(resultado);
                    }
                    else
                    {
                        throw new Exception(resultado);
                    }
                }                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CoinBaseBalance> GetBalance(CoinBaseAccount account)
        {
            try
            {
                using HttpRequestMessage requisicao = GetRequest(HttpMethod.Get, "/accounts/" + account.Id);
                HttpResponseMessage resposta = await HTTPClient.SendAsync(requisicao);

                string resultado = await resposta.Content.ReadAsStringAsync();

                if (resposta.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<CoinBaseBalance>(resultado);
                }
                else
                {
                    throw new Exception(resultado);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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

        /// <summary>
        /// Seta a autorização ja buscando o TimeStamp automaticamente
        /// </summary>
        /// <param name="authorization">Um objeto do tipo <see cref="CoinBaseAuthorization" /> com as informações</param>
        public void SetAuthorization(CoinBaseAuthorization authorization)
        {
            Authorization = authorization;
            Authorization.TimeStamp = Task.Run(() => GetTimeFromServer()).GetAwaiter().GetResult();
        }

        

        public async Task<List<CoinBaseAccount>> GetAccounts()
        {
            try
            {
                using HttpRequestMessage requisicao = GetRequest(HttpMethod.Get, "/accounts");
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

        private HttpRequestMessage GetRequest(HttpMethod method, string url, string jsonBody = null)
        {
            if (!Authorization.isValid())
            {
                throw new AuthorizationException("Para essa operação, são necessarias as informações de Authorização do usuario");
            }

            HttpRequestMessage requisicao = new HttpRequestMessage(method, HTTPClient.BaseAddress + url);
            requisicao.Headers.Add("CB-ACCESS-KEY", Authorization.Key);
            requisicao.Headers.Add("CB-ACCESS-SIGN", Authorization.GetSign(url, method, jsonBody));
            requisicao.Headers.Add("CB-ACCESS-TIMESTAMP", Authorization.TimeStamp);
            requisicao.Headers.Add("CB-ACCESS-PASSPHRASE", Authorization.PassPhrase);

            if (!string.IsNullOrWhiteSpace(jsonBody))
            {
                requisicao.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            return requisicao;
        }

        private async Task<string> GetTimeFromServer()
        {
            try
            {
                HttpResponseMessage requisicao = await HTTPClient.GetAsync("/time");
                string conteudo = await requisicao.Content.ReadAsStringAsync();

                if (requisicao.IsSuccessStatusCode)
                {
                    return JObject.Parse(conteudo).GetValue("epoch").ToObject<string>();
                }
                else
                {
                    throw new Exception(conteudo);
                }                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
