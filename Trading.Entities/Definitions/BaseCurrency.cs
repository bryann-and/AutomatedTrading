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
        string Symbol { get; set; }
        /// <summary>
        /// Nome da moeda, por exemplo "Bitcoin"
        /// </summary>
        string Name { get; set; }
    }
}
