using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.CoinBasePro
{
    public sealed class CoinBaseAccount : BaseAccount
    {
        public decimal Balance { get; set; }
        public decimal Hold { get; set; }
        public decimal Available { get; set; }
        public string Currency { get; set; }
        public string Profile_id { get; set; }
    }
}
