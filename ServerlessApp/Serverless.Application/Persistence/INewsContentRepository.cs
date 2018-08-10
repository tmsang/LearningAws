using Serverless.Domain.News;
using System.Collections.Generic;

namespace Serverless.Application.Persistence
{
	public interface INewsContentRepository: IGenericRepository<NewsContent>
    {
		NewsContent FindById(int id);
		IEnumerable<NewsContent> FindByIds(IEnumerable<int> ids);
		IEnumerable<NewsContent> FindAll();
	}
}
