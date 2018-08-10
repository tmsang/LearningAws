using Serverless.Application.Persistence;
using Serverless.Domain.News;
using System.Collections.Generic;
using System.Linq;

namespace Serverless.Persistence.Dynamo.Repositories
{
	public class NewsStatesRepository: BaseRepository<NewsStates>, INewsStatesRepository
	{
		public NewsStatesRepository(ServerlessDbContext dbContext) : base(dbContext)
		{			
		}

		public NewsStates FindById(int id) {
			return GetById(id);
		}

		public IEnumerable<NewsStates> FindByIds(IEnumerable<int> ids) {
			return GetByIds(ids);
		}

		public IEnumerable<NewsStates> FindByNewsId(int newsId) {
			var newsList = GetAll().Where(p => p.NewsContentId == newsId);
			return newsList;
		}

		public IEnumerable<NewsStates> FindAll() {
			return GetAll();
		}
	}
}
