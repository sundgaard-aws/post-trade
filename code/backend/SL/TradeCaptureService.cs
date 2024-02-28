using DTL;
using DAL;

namespace SL
{
    public class TradeCaptureService
    {
        private ITradeDAC tradeDAC;

        public TradeCaptureService(ITradeDAC tradeDAC) {
            this.tradeDAC=tradeDAC;
        }
        
        public async Task CaptureTradeDetails(Trade trade)
        {
            var tradeConfirmation = new TradeConfirmation
            {
                TradeId = trade.TradeID,
                SecurityISIN = trade.SecurityISIN,
                Quantity = trade.Quantity,
                Price = trade.Price,
                TradeDate = trade.TradeDate,
                SettlementDate = trade.SettlementDate,
                TradeType = trade.TradeType,
                TraderId = trade.TraderID,
                CounterpartyID = trade.CounterpartyID
            };

            await tradeDAC.StoreTradeAsync(trade);
        }
    }

}