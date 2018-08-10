using Serverless.Domain.Abstractions;
using System.Collections.Generic;

namespace Serverless.Application.Persistence
{
	public interface IGenericRepository<T> where T: IRootEntity
    {		
		IEnumerable<T> GetAll();
		IEnumerable<T> GetByIds(IEnumerable<int> ids);
		T GetById(int id);

		T Create(T entity);		
		T Update(T entity);
		void Delete(int id);
	}
}
