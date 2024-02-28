namespace DTL
{
    public class ReconciliationResult
    {
        public enum ReconciliationStatusEnum{Unmatched, Matched,
            PartialMatch,
            PaymentNotMatched,
            TradeNotMatched
        }
        public string TradeID { get; set; }
        public object PaymentID { get; set; }
        public ReconciliationStatusEnum ReconciliationStatus { get; set; }
    }
}