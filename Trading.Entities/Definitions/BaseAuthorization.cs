namespace Trading.Entities.Definitions
{
    /// <summary>
    /// Difinição do modelo basico de autorização requerida pelas APIs disponibilizadas pelos Exchanges
    /// </summary>
    public class BaseAuthorization
    {
        /// <summary>
        /// Tambem conhecido como Token
        /// </summary>
        public string Key { get; set; }

        public BaseAuthorization(string key)
        {
            Key = key;
        }
    }
}
