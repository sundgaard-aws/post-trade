using Amazon.DynamoDBv2.DataModel;

namespace DTL
{
    [DynamoDBTable("Trades")] public class Trade
    {
        [DynamoDBHashKey] public string TradeID { get; set; }
        [DynamoDBProperty] public string Currency { get; set; }
        [DynamoDBProperty] public decimal Amount { get; set; }
        [DynamoDBProperty] public decimal Price { get; set; }
        [DynamoDBProperty] public DateTime TradeDate { get; set; }
        [DynamoDBProperty] public DateTime SettlementDate { get; set; }
        [DynamoDBProperty] public string TradeType { get; set; }
        [DynamoDBProperty] public string TraderID { get; set; }
        [DynamoDBProperty] public string SecurityISIN { get; set; }
        [DynamoDBProperty] public decimal Quantity { get; set; }
        [DynamoDBProperty] public string CounterpartyID { get; set; }
    }
}