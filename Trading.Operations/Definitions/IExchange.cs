using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Entities.Definitions;

namespace Trading.Operations.Definitions
{
    /// <summary>
    /// Definição das propriedades e metodos basicos de operações fornecidas pelos Exchanges
    /// </summary>
    public interface IExchange
    {
        /// <summary>
        /// Busca as informações de valores de uma moeda especifica no Exchange
        /// </summary>
        /// <param name="currency">Um objeto <see cref="BaseCurrency"/> com os dados da moeda a ser buscada as informações</param>
        /// <returns>Um objeto <see cref="BaseCurrency"/> com os dados da moeda</returns>
        BaseCurrency GetTicker(BaseCurrency currency);

        /// <summary>
        /// Busca as informações de valores de todas as moedas no Exchange
        /// </summary>
        /// <returns>Uma <see cref="Task<List<>>"/> de moedas</returns>
        Task<List<BaseCurrency>> GetAllTickers();

        /// <summary>
        /// Busca todos os assets disponiveis em todas as contas do usuário
        /// </summary>
        /// <returns>Um objeto <see cref="BaseBalance"/> com o balanço da conta</returns>
        BaseBalance GetBalance();

        /// <summary>
        /// Busca todos os assets disponiveis em uma conta especifica
        /// </summary>
        /// <param name="account">A conta que se deseja buscar o balanço</param>
        /// <returns>Um objeto <see cref="BaseBalance"/> com o balanço da conta</returns>
        Task<BaseBalance> GetBalance(BaseAccount account);

        /// <summary>
        /// Busca as contas disponiveis
        /// </summary>
        /// <returns>Uma <see cref="List<>"/> com as contas</returns>
        Task<List<BaseAccount>> GetAccounts();

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
