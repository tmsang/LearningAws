using Funq;
using Serverless.Catalog.Api.Models;
using ServiceStack;
using ServiceStack.Aws.DynamoDb;

namespace Serverless.Catalog.Api
{
    public class AppHost: AppHostBase
    {
        public AppHost(): base("AWS Examples", typeof(AppHost).Assembly) {

        }        

        public IPocoDynamo PocoDynamo { get; set; }

        public override void Configure(Container container)
        {
            container.Register<IPocoDynamo>(c => new PocoDynamo(AwsConfig.CreateAmazonDynamoDb()));
            PocoDynamo = container.Resolve<IPocoDynamo>();
            PocoDynamo.RegisterTable<CatalogItem>();
            //db.RegisterTable<EmailContacts.Email>();
            //db.RegisterTable<EmailContacts.Contact>();
            PocoDynamo.InitSchema();
        }
    }
}
