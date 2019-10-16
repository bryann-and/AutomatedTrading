using System.Collections.Generic;
using System.Net.Http;
using Trading.Entities.Definitions;

namespace Trading.Operations.Definitions
{
    /// <summary>
    /// Definição das propriedades e metodos basicos de operações fornecidas pelos Exchanges
    /// </summary>
    public interface IExchange
    {
        /// <summary>
        /// Usado para fazer todas as requisições, deve ser feito a injeçãoi de dependencia dessa propriedade
        /// </summary>
        HttpClient Cliente { get; set; }

        /// <summary>
        /// Armazena as informações de Autorização necessarias para realizar todas as transações disponiveis
        /// </summary>
        IAuthorization Authorization { get; set; }

        /// <summary>
        /// Busca as informações de valores no Exchange
        /// </summary>
        /// <returns>Uma <see cref="List<>"/> de moedas</returns>
        List<ICurrency> GetTicker();

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
