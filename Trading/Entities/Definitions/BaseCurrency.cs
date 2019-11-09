namespace Trading.Entities.Definitions
{
    /// <summary>
    /// Definição do modelo basico de uma Moeda
    /// </summary>
    public class BaseCurrency
    {
        /// <summary>
        /// Simbolo da moeda, por exemplo: "BTC"
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// Nome da moeda, por exemplo "Bitcoin"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Usado quando é buscado o balanço da conta
        /// </summary>
        public double Avaliable { get;set; }
    }
}
