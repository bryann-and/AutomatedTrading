using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Entities.Definitions;

namespace Trading.Operations.Definitions
{
    /// <summary>
    /// Definição das propriedades e metodos basicos de operações fornecidas pelos Exchanges
    /// </summary>
    public interface IExchange<AuthorizationType, CurrencyType, BalanceType, AccountType, TickerType>
    {
        AuthorizationType Authorization { get; set; }

        /// <summary>
        /// Busca as informações de valores de uma moeda especifica no Exchange
        /// </summary>
        /// <param name="currency">Um objeto <see cref="CurrencyType"/> com os dados da moeda a ser buscada as informações</param>
        /// <returns>Um objeto <see cref="CurrencyType"/> com os dados da moeda</returns>
        Task<TickerType> GetTicker(CurrencyType currency);

        /// <summary>
        /// Busca todos os assets disponiveis em todas as contas do usuário
        /// </summary>
        /// <returns>Um objeto <see cref="BalanceType"/> com o balanço da conta</returns>
        BalanceType GetBalance();

        /// <summary>
        /// Busca as contas disponiveis
        /// </summary>
        /// <returns>Uma <see cref="List<>"/> com as contas</returns>
        Task<List<AccountType>> GetAccounts();

        /// <summary>
        /// Cria uma ordem de compra
        /// </summary>
        /// <returns>Um objeto <see cref="IOrder"/> com o id da ordem</returns>
        IOrder CreateOrder();

        /// <summary>
        /// Cancela uma ordem de compra
        /// </summary>
        /// <param name="order">Ordem a ser cancelada</param>
        /// <returns>Um <see cref="bool"/> dizendo se a ordem foi cancelada ou não</returns>
        bool CancelOrder(IOrder order);
    }
}
