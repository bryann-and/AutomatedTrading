using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.KuCoin
{
    public class KuCoinCurrency : BaseCurrency
    {
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

        #region Usado em balanço de conta
        public double Balance { get; set; }
        public decimal Holds { get; set; }
        public string Currency { get => Symbol; set => Symbol = value; }
        #endregion
    }
}
