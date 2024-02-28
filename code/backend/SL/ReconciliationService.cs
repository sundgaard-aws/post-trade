using DTL;
using static DTL.ReconciliationResult;

namespace SL
{
    public class ReconciliationService
    {
        public IEnumerable<ReconciliationResult> Reconciliation(IEnumerable<Trade> trades, IEnumerable<Payment> payments)
        {
            var tradesLookup = trades.ToDictionary(t => GetTradeKey(t), t => t);
            var paymentsLookup = payments.ToDictionary(p => GetPaymentKey(p), p => p);

            var matchedKeys = new HashSet<string>();

            // Match trades and payments based on key attributes
            foreach (var tradeKey in tradesLookup.Keys)
            {
                if (paymentsLookup.TryGetValue(tradeKey, out var payment))
                {
                    matchedKeys.Add(tradeKey);

                    // Check for additional attributes for a more comprehensive reconciliation
                    var trade = tradesLookup[tradeKey];
                    if (IsReconciliationMatch(trade, payment))
                    {
                        yield return new ReconciliationResult
                        {
                            TradeID = trade.TradeID,
                            PaymentID = payment.PaymentID,
                            ReconciliationStatus = ReconciliationStatusEnum.Matched
                        };
                    }
                    else
                    {
                        yield return new ReconciliationResult
                        {
                            TradeID = trade.TradeID,
                            PaymentID = payment.PaymentID,
                            ReconciliationStatus = ReconciliationStatusEnum.PartialMatch
                        };
                    }
                }
            }

            // Generate reconciliation results for unmatched trades and payments
            foreach (var trade in trades)
            {
                var tradeKey = GetTradeKey(trade);
                if (!matchedKeys.Contains(tradeKey))
                {
                    yield return new ReconciliationResult
                    {
                        TradeID = trade.TradeID,
                        ReconciliationStatus = ReconciliationStatusEnum.TradeNotMatched
                    };
                }
            }

            foreach (var payment in payments)
            {
                var paymentKey = GetPaymentKey(payment);
                if (!matchedKeys.Contains(paymentKey))
                {
                    yield return new ReconciliationResult
                    {
                        PaymentID = payment.PaymentID,
                        ReconciliationStatus = ReconciliationStatusEnum.PaymentNotMatched
                    };
                }
            }
        }

        private string GetTradeKey(Trade trade)
        {
            return $"{trade.CounterpartyID}_{trade.SecurityISIN}_{trade.TradeDate.Date}_{trade.SettlementDate.Date}_{trade.Amount}";
        }

        private string GetPaymentKey(Payment payment)
        {
            return $"{payment.CounterpartyID}_{payment.SecurityISIN}_{payment.PaymentDate}_{payment.Amount}";
        }

        private bool IsReconciliationMatch(Trade trade, Payment payment)
        {
            // Add additional matching criteria here based on your requirements
            return trade.TradeType == payment.PaymentType;
        }
    }

}