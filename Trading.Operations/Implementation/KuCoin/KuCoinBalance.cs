using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.KuCoin
{
    public class KuCoinBalance : BaseBalance
    {
        public string Currency { get => Symbol; set => Symbol = value; }
        public string Type { get; set; }
    }
}
