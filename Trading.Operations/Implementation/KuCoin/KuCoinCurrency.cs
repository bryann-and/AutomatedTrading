using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.KuCoin
{
    public class KuCoinCurrency : BaseCurrency
    {
        /// <summary>
        /// Simbolo da moeda, por exemplo: "BTC"
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// Nome da moeda, por exemplo "Bitcoin"
        /// </summary>
        public string Name { get; set; }

        public string SymbolName { get => Name; set => Name = value; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        public decimal ChangeRate { get; set; }
        public decimal ChangePrice { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Vol { get; set; }
        public decimal VolValue { get; set; }
        public decimal Last { get; set; }
    }
}
