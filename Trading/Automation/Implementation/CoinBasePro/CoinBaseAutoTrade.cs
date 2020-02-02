using Database.Context;
using Database.Services;
using Database.Entities.CoinBase;
using System;
using Trading.Automation.Definitions;
using Trading.Entities.Definitions;
using Trading.Operations.Implementation.CoinBasePro;
using Database.Entities.Base;
using Database.Entities.System;
using Database.Entities.Enums;

namespace Trading.Automation.Implementation.CoinBasePro
{
    public class CoinBaseAutoTrade : IAutoTrade<CoinBaseOrder, CoinBaseProduct>
    {
        private CoinBaseExchange Exchange { get; set; }
        private Func<AutoTradingContext> Context { get; set; }
        private Usuario Usuario { get; set; }

        public CoinBaseAutoTrade(Usuario usuario, CoinBaseExchange exchange, Func<AutoTradingContext> contexto)
        {
            Usuario = usuario;
            Exchange = exchange;
            Context = contexto;            
        }

        public CoinBaseOrder Comprar(CoinBaseProduct destino)
        {
            // Chamar função da API

            // Inserir no banco
        }

        public CoinBaseOrder Vender(CoinBaseProduct origem)
        {
            // Chamar função da API

            // Inserir no banco
        }

        private CoinBaseOrder PersistirOrder(CoinBaseOrder order, OrderType tipo, OrderSide lado)
        {
            DbService<CoinBaseOrder> coinBaseOrderService = new DbService<CoinBaseOrder>(Context);
            order.BaseOrder = new BaseOrder
            {
                CodigoUsuario = Usuario.Codigo,
                Lado = lado,
                Tipo = tipo
            };

            return coinBaseOrderService.Criar(order);
        }
    }
}
