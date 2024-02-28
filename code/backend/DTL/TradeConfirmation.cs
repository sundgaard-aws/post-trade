using Amazon.DynamoDBv2.DataModel;

namespace DTL
{
    [DynamoDBTable("TradeConfirmations")] public class TradeConfirmation
    {
        [DynamoDBHashKey] public string TradeId { get; set; }
        [DynamoDBProperty] public string Currency { get; set; }
        [DynamoDBProperty] public decimal Amount { get; set; }
        [DynamoDBProperty] public decimal Price { get; set; }
        [DynamoDBProperty] public DateTime TradeDate { get; set; }
        [DynamoDBProperty] public DateTime SettlementDate { get; set; }
        [DynamoDBProperty] public string TradeType { get; set; }
        [DynamoDBProperty] public string TraderId { get; set; }
        [DynamoDBProperty] public object SecurityISIN { get; set; }
        [DynamoDBProperty] public object Quantity { get; set; }
        [DynamoDBProperty] public object CounterpartyID { get; set; }
    }
}