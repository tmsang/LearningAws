using Funq;
using Serverless.Domain.News;
using ServiceStack;
using ServiceStack.Aws.DynamoDb;

namespace Serverless.Persistence.Dynamo
{
	public class AppHost : AppHostBase
	{
		public AppHost() : base("AWS Serverless", typeof(AppHost).Assembly)
		{

		}

		public IPocoDynamo PocoDynamo { get; set; }

		public override void Configure(Container container)
		{
			container.Register<IPocoDynamo>(c => new PocoDynamo(AwsConfig.CreateAmazonDynamoDb()));
			PocoDynamo = container.Resolve<IPocoDynamo>();
			PocoDynamo.RegisterTable<NewsContent>();
			PocoDynamo.RegisterTable<NewsStates>();

			//db.RegisterTable<EmailContacts.Email>();
			//db.RegisterTable<EmailContacts.Contact>();
			PocoDynamo.InitSchema();
		}
	}
}
