using ServiceStack.Aws.DynamoDb;

namespace Serverless.Persistence.Dynamo
{
	public class ServerlessDbContext
    {		
		public IPocoDynamo Database { get; }

		public ServerlessDbContext()
		{
			var appHost = new AppHost();
			appHost.Init();

			Database = appHost.PocoDynamo;
		}

    }
}
