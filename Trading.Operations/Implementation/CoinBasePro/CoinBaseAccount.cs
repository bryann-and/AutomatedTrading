using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.CoinBasePro
{
    public sealed class CoinBaseAccount : BaseAccount
    {
        public string Balance { get; set; }
        public string Hold { get; set; }
        public string Available { get; set; }
        public string Currency { get; set; }
        public string Profile_id { get; set; }
    }
}
