using Database.Entities.Base;
using Trading.Entities.Definitions;

namespace Trading.Automation.Definitions
{
    interface IAutoTrade<OrderType, CurrencyType>
    {
        /// <summary>
        /// Realizar uma Compra
        /// </summary>
        /// <param name="destino">Moeda a ser comprada</param>
        OrderType Comprar(CurrencyType destino);

        /// <summary>
        /// Vende uma moeda
        /// </summary>
        /// <param name="origem">Moeda a ser vendida</param>
        OrderType Vender(CurrencyType origem);

        /// <summary>
        /// Busca a ultima operação realizada
        /// </summary>
        OrderType BuscarUltimaOperacao();
    }
}
