using ServiceStack.Aws.DynamoDb;

namespace Serverless.Catalog.Api.Services.Common
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
