﻿namespace Trading.Entities.Definitions
{
    /// <summary>
    /// Difinição do modelo basico de autorização requerida pelas APIs disponibilizadas pelos Exchanges
    /// </summary>
    public interface IAuthorization
    {
        /// <summary>
        /// Tambem conhecida como Token
        /// </summary>
        string Key { get; set; }
    }
}
