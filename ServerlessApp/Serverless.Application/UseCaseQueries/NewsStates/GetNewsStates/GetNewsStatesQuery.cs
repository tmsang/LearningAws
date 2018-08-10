using Serverless.Application.Persistence;
using Serverless.Application.UseCaseSharedModels;
using System.Collections.Generic;
using System.Linq;

namespace Serverless.Application.UseCaseQueries.NewsStates
{
	public class GetNewsStatesQuery: IGetNewsStatesQuery
    {
		private readonly INewsStatesRepository _newsStatesRepository;

		public GetNewsStatesQuery(INewsStatesRepository newsStatesRepository)
		{
			_newsStatesRepository = newsStatesRepository;
		}

		public IEnumerable<NewsStatesModel> FindByNewsId(int newsId)
		{
			var list = _newsStatesRepository.FindByNewsId(newsId).Select(p => new NewsStatesModel(p));

			return list;
		}

		public IEnumerable<NewsStatesModel> FindAll() {
			var list = _newsStatesRepository.FindAll().Select(p => new NewsStatesModel(p));

			return list;
		}

		public NewsStatesModel FindById(int id) {
			var newsState = _newsStatesRepository.FindById(id);

			return new NewsStatesModel(newsState);
		}
	}	
}
