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
        // Serviços de acesso ao banco
        private DbService<CoinBaseOrder> coinBaseOrderService { get; set; }


        private CoinBaseExchange Exchange { get; set; }
        private Func<AutoTradingContext> Context { get; set; }
        private Usuario Usuario { get; set; }

        public CoinBaseAutoTrade(Usuario usuario, CoinBaseExchange exchange, Func<AutoTradingContext> contexto)
        {
            Usuario = usuario;
            Exchange = exchange;
            Context = contexto;            
            coinBaseOrderService = new DbService<CoinBaseOrder>(Context);
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

        public CoinBaseOrder BuscarUltimaOperacao()
        {
            return coinBaseOrderService.BuscarUltimo(o => o.BaseOrder.CodigoUsuario == Usuario.Codigo);
        }

        private CoinBaseOrder PersistirOrder(CoinBaseOrder order, OrderType tipo, OrderSide lado)
        {
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
