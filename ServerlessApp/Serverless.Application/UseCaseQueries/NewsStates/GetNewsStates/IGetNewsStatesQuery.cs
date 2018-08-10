using Serverless.Application.UseCaseSharedModels;
using System.Collections.Generic;

namespace Serverless.Application.UseCaseQueries.NewsStates
{
	public interface IGetNewsStatesQuery
    {
		IEnumerable<NewsStatesModel> FindAll();
		NewsStatesModel FindById(int id);
		IEnumerable<NewsStatesModel> FindByNewsId(int newsId);
	}
}
