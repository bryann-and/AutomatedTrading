using System.Net.Http;

namespace Trading.Operations.Definitions
{
    public class BaseExchange<AuthorizationType, EndPointsType>
    {
        protected HttpClient HTTPClient { get; set; }

        protected AuthorizationType Authorization { get; set; }

        protected EndPointsType EndPoints { get; set; }

        public BaseExchange(HttpClient httpClient, EndPointsType endPoints)
        {
            HTTPClient = httpClient;
            EndPoints = endPoints;
        }
    }
}
