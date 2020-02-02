using Database.Entities.Base;
using Database.Entities.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Database.Entities.CoinBase
{
    public sealed class CoinBaseOrder : BaseOrder
    {
        public long? BaseOrderId { get; set; }
        public BaseOrder BaseOrder { get; set; }

        public string OrderId { get; set; }
        public string Status { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }
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

        [JsonProperty("time_in_force")]
        public string TimeInForce { get; set; }

        [JsonProperty("post_only")]
        public bool? PostOnly { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("fill_fees")]
        public decimal? FillFees { get; set; }

        [JsonProperty("filled_size")]
        public decimal? FilledSize { get; set; }

        [JsonProperty("executed_value")]
        public decimal? ExecutedValue { get; set; }

        public bool? Settled { get; set; }

        /// <summary>
        /// Retorna o objeto no formato de Json
        /// </summary>
        /// <returns>O Json do objeto</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
}
