using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.CoinBasePro
{
    /// <summary>
    /// Chamado de Product no CoinBase, mas é o mesmo de Currency
    /// </summary>
    public sealed class CoinBaseProduct : BaseCurrency
    {
        public string Id { get => Symbol; set => Symbol = value; }

        public string base_currency { get; set; }

        public string quote_currency { get; set; }

        public double base_min_size { get; set; }

        public double base_max_size { get; set; }

        public double quote_increment { get; set; }
    }
}
