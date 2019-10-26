namespace Trading.Entities.Definitions
{
    /// <summary>
    /// Difinição do modelo basico de autorização requerida pelas APIs disponibilizadas pelos Exchanges
    /// </summary>
    public interface IAuthorization
    {
        /// <summary>
        /// Tambem conhecido como Token
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Verifica se a autorização esta corretamente preenchida
        /// </summary>
        /// <returns>Um <see cref="bool"/> dizendo se esta tudo correto</returns>
        bool isValid();
    }
}
