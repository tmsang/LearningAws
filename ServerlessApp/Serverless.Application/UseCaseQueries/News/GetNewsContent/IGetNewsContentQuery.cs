using Serverless.Application.UseCaseSharedModels;
using System.Collections.Generic;

namespace Serverless.Application.UseCaseQueries.News
{
	public interface IGetNewsContentQuery
    {
		NewsContentModel FindById(int id);
		IEnumerable<NewsContentModel> FindAll();
    }
}
