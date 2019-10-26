using System;
using System.Net.Http;
using Trading.Entities.Definitions;

namespace Trading.Operations.Definitions
{
    public class BaseExchange
    {
        protected HttpClient HTTPClient { get; set; }

        public BaseExchange(HttpClient httpClient)
        {
            HTTPClient = httpClient;
        }
    }
}
