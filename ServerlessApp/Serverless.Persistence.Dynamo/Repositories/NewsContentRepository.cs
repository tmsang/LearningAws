using Serverless.Application.Persistence;
using Serverless.Domain.News;
using System.Collections.Generic;

namespace Serverless.Persistence.Dynamo.Repositories
{
	public class NewsContentRepository: BaseRepository<NewsContent>, INewsContentRepository
    {		
		public NewsContentRepository(ServerlessDbContext dbContext): base(dbContext)
		{
			
		}

		public NewsContent FindById(int id) {
			return GetById(id);
		}

		public IEnumerable<NewsContent> FindByIds(IEnumerable<int> ids) {
			return GetByIds(ids);
		}

		public IEnumerable<NewsContent> FindAll() {
			return GetAll();
		}
	}
}
