using Serverless.Domain.Abstractions;
using ServiceStack.DataAnnotations;

namespace Serverless.Domain.News
{
    public class NewsStates: BaseEntity, IRootEntity
	{
		[AutoIncrement]
		public int Id { get; set; }
        public string Status { get; set; }

		[References(typeof(NewsContent))]
        public int NewsContentId { get; set; }

		protected override string GetId()
		{
			return Id.ToString();
		}

		[Ignore]
		public bool Deleted { get; set; }
	}
}
