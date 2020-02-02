using Database.Entities.CoinBase;
using Trading.Operations.Implementation.CoinBasePro;

namespace Trading.Operations.ExchangeEndpoints
{
    public class CoinBaseProEndpoints
    {
        public string Base { get; set; }

        public string Orders { get; set; }

        public string Accounts { get; set; }

        public string Products { get; set; }

        public string Time { get; set; }

        public string Ticker { get; set; }

        public string GetEndpointProductTicker(CoinBaseProduct currency)
        {
            return Products + "/" + currency.Id + Ticker;
        }

        public string GetEndpointOrderId(CoinBaseOrder order)
        {
            return Orders + "/" + order.OrderId;
        }

        public string GetEndpointAccountId(CoinBaseAccount account)
        {
            return Accounts + "/" + account.Id;
        }
    }
}
