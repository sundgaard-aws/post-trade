using DTL;

namespace DAL;
public interface ITradeDAC
{
    Task StoreTradeAsync(Trade trade);
}
