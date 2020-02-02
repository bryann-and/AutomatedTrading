using Database.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Entities.Definitions;

namespace Trading.Operations.Definitions
{
    /// <summary>
    /// Definição das propriedades e metodos basicos de operações fornecidas pelos Exchanges
    /// </summary>
    public interface IExchange<AuthorizationType, CurrencyType, BalanceType, AccountType, TickerType, OrderType>
    {
        /// <summary>
        /// Busca as informações de valores de uma moeda especifica no Exchange
        /// </summary>
        /// <param name="currency">Um objeto <see cref="CurrencyType"/> com os dados da moeda a ser buscada as informações</param>
        /// <returns>Um objeto <see cref="CurrencyType"/> com os dados da moeda</returns>
        Task<TickerType> GetTicker(CurrencyType currency);

        /// <summary>
        /// Busca todos os assets disponiveis em todas as contas do usuário
        /// </summary>
        /// <param name="account">Um objeto <see cref="AccountType"/> com a conta a ser buscada o balanço</param>
        /// <returns>Um objeto <see cref="BalanceType"/> com o balanço da conta</returns>
        Task<BalanceType> GetBalance(AccountType account);

        /// <summary>
        /// Busca as contas disponiveis
        /// </summary>
        /// <returns>Uma <see cref="List<>"/> com as contas</returns>
        Task<List<AccountType>> GetAccounts();

        /// <summary>
        /// Cria uma ordem
        /// </summary>
        /// <param name="order">Ordem a ser criada</param>
        /// <returns>Um objeto <see cref="OrderType"/> com as informações da ordem</returns>
        Task<OrderType> CreateOrder(OrderType order);

        /// <summary>
        /// Busca as informações atualizadas de uma ordem
        /// </summary>
        /// <param name="order">Um objeto <see cref="OrderType"/> a ter as informações buscadas</param>
        /// <returns>Um objeto <see cref="OrderType"/> com informações atualizadas</returns>
        OrderType GetOrder(OrderType order);

        /// <summary>
        /// Cancela uma ordem de compra
        /// </summary>
        /// <param name="order">Ordem a ser cancelada</param>
        /// <returns>Um <see cref="bool"/> dizendo se a ordem foi cancelada ou não</returns>
        bool CancelOrder(OrderType order);


        /// <summary>
        /// Seta a autorização com as informações do usuario no Exchange
        /// </summary>
        /// <param name="authorization">Um objeto do tipo <see cref="AuthorizationType"/> com as informações</param>
        void SetAuthorization(AuthorizationType authorization);
    }
}
