namespace Trading.Entities.Definitions
{
    /// <summary>
    /// Definição do modelo basico de uma Moeda
    /// </summary>
    public interface ICurrency
    {
        /// <summary>
        /// Simbolo da moeda, por exemplo: "BTC"
        /// </summary>
        string symbol { get; set; }
        /// <summary>
        /// Nome da moeda, por exemplo "Bitcoin"
        /// </summary>
        string name { get; set; }
    }
}
