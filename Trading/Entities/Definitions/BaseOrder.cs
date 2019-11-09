namespace Trading.Entities.Definitions
{
    /// <summary>
    /// Definição do modelo basico de uma ordem de compra/venda
    /// </summary>
    public class BaseOrder
    {
        public OrderType Tipo { get; set; }
        public OrderSide Lado { get; set; }
    }
}
