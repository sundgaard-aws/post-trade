using DTL;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DAL;

namespace DynamoDBDAL
{
    public class TradeDAC : ITradeDAC
    {
        public async Task StoreTradeAsync(Trade trade)
        {
            var dynamoDbClient = new AmazonDynamoDBClient(RegionEndpoint.GetBySystemName("eu-north-1"));
            var dynamoDbContext = new DynamoDBContext(dynamoDbClient);
            await dynamoDbContext.SaveAsync(trade);
        }
    }
}