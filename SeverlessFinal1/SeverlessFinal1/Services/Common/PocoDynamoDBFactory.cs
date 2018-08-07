using ServiceStack.Aws.DynamoDb;

namespace SeverlessFinal1.Services.Common
{
    public static class PocoDynamoDBFactory
    {
        public static IPocoDynamo Database;

        static PocoDynamoDBFactory() {
            var appHost = new AppHost();
            appHost.Init();

            Database = appHost.PocoDynamo;
        }
    }
}
