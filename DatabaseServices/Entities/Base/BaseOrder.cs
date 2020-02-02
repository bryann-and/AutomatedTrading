using Database.Entities.Enums;
using Database.Entities.System;

namespace Database.Entities.Base
{
    /// <summary>
    /// Definição do modelo basico de uma ordem de compra/venda
    /// </summary>
    public class BaseOrder
    {
        public long? Codigo { get; set; }

        public long? CodigoUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public OrderType Tipo { get; set; }
        public OrderSide Lado { get; set; }
    }
}
