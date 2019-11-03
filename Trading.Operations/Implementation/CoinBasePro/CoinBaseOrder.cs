using System;
using Trading.Entities.Definitions;

namespace Trading.Operations.Implementation.CoinBasePro
{
    public sealed class CoinBaseOrder : BaseOrder
    {
        public string Product_id { get; set; }
        public decimal? Price { get; set; }
        public string Side
        {
            get
            {
                switch (Lado)
                {
                    case OrderSide.Buy:
                        return "buy";
                    case OrderSide.Sell:
                        return "sell";
                    default:
                        throw new ArgumentException("Lado de order invalido");
                }
            }
            set
            {
                switch (value)
                {
                    case "buy":
                        Lado = OrderSide.Buy;
                        break;
                    case "sell":
                        Lado = OrderSide.Sell;
                        break;
                    default:
                        throw new ArgumentException("Lado de order invalido, recebido: " + value);
                }
            }
        }
        public string Type
        {
            get
            {
                switch (Tipo)
                {
                    case OrderType.Market:
                        return "market";
                    case OrderType.Limit:
                        return "limit";
                    default:
                        throw new ArgumentException("Tipo de order invalido");
                }
            }
            set
            {
                switch (value)
                {
                    case "market":
                        Tipo = OrderType.Market;
                        break;
                    case "limit":
                        Tipo = OrderType.Limit;
                        break;
                    default:
                        throw new ArgumentException("Tipo de order invalido, recebido: " + value);
                }
            }
        }
        public decimal? Size { get; set; }
        public decimal? Funds { get; set; }

        public string Stp { get; set; }
        public string Time_in_force { get; set; }
        public bool? Post_only { get; set; }
        public DateTime? Created_at { get; set; }
        public decimal? Fill_fees { get; set; }
        public decimal? Filled_size { get; set; }
        public decimal? Executed_value { get; set; }
        public bool? Settled { get; set; }
    }
}
