namespace Trading.Entities.Definitions
{
    public class BaseBalance
    {
        public string Symbol { get; set; }
        public decimal Avaliable { get; set; }
        public decimal Holds { get; set; }
    }
}
