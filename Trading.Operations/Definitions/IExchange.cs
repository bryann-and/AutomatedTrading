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
        /// Armazena as informações de Autorização necessarias para realizar todas as transações disponiveis que não são publicas
        /// </summary>
        IAuthorization Authorization { get; set; }

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
        /// Busca todos os assets disponiveis em conta do usuário
        /// </summary>
        /// <returns>Um objeto <see cref="IBalance"/> com o balanço da conta</returns>
        IBalance GetBalance();

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
