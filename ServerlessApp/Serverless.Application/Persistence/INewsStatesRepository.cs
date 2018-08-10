using Serverless.Domain.News;
using System.Collections.Generic;

namespace Serverless.Application.Persistence
{
	public interface INewsStatesRepository: IGenericRepository<NewsStates>
	{
		NewsStates FindById(int id);
		IEnumerable<NewsStates> FindByIds(IEnumerable<int> ids);
		IEnumerable<NewsStates> FindByNewsId(int newsId);
		IEnumerable<NewsStates> FindAll();
	}
}
