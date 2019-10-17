using System.Collections.Generic;

namespace Trading.Entities.Definitions
{
    public interface IBalance
    {
        List<ICurrency> Currencies { get; set; }
    }
}
