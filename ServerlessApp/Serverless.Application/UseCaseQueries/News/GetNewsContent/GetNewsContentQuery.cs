using Serverless.Application.Persistence;
using Serverless.Application.UseCaseSharedModels;
using System.Collections.Generic;
using System.Linq;

namespace Serverless.Application.UseCaseQueries.News
{
	public class GetNewsContentQuery: IGetNewsContentQuery
    {
		private readonly INewsContentRepository _newsContentRepository;

		public GetNewsContentQuery(INewsContentRepository newsContentRepository)
		{
			_newsContentRepository = newsContentRepository;
		}

		public NewsContentModel FindById(int id) {
			var newsContent = _newsContentRepository.FindById(id);

			return new NewsContentModel(newsContent);
		}

		public IEnumerable<NewsContentModel> FindAll() {
			var newsContents = _newsContentRepository.FindAll().Select(p => new NewsContentModel(p));

			return newsContents;
		}
	}
}
