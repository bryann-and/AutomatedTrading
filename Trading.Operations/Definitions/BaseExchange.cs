using System.Net.Http;

namespace Trading.Operations.Definitions
{
    public class BaseExchange<AuthorizationType>
    {
        protected HttpClient HTTPClient { get; set; }

        protected AuthorizationType Authorization { get; set; }

        public BaseExchange(HttpClient httpClient)
        {
            HTTPClient = httpClient;
        }
    }
}
