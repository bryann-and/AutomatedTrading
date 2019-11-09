using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.CoinBasePro
{
    public sealed class CoinBaseBalance : BaseBalance
    {
        public string Id { get; set; }
        public string Balance { get; set; }
        public string Currency { get => Symbol; set => Symbol = value; }
    }
}
