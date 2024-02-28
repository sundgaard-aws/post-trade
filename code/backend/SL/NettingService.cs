using DTL;

namespace SL
{
    public class NettingService
    {
        public IEnumerable<NettingResult> NetTradesLazy(IEnumerable<Trade> trades)
        {
            {
                // Group trades by counterparty
                var groupedTrades = trades.GroupBy(t => t.CounterpartyID);

                // Perform netting for each counterparty
                foreach (var group in groupedTrades)
                {
                    var counterpartyID = group.Key;
                    var nettingResult = new NettingResult
                    {
                        CounterpartyID = counterpartyID,
                        NetPosition = 0
                    };

                    // Calculate net position by summing the trade amounts
                    foreach (var trade in group)
                    {
                        nettingResult.NetPosition += trade.Amount;
                    }

                    yield return nettingResult;
                }
            }
        }                    
    }
}