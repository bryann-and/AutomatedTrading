using System.Collections.Generic;

namespace Trading.Entities.Definitions
{
    public interface IBalance
    {
        List<BaseCurrency> Currencies { get; set; }
    }
}
