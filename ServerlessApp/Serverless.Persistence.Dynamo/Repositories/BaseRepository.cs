using Serverless.Application.Persistence;
using Serverless.Domain.Abstractions;
using ServiceStack.Aws.DynamoDb;
using System.Collections.Generic;

namespace Serverless.Persistence.Dynamo.Repositories
{
	public abstract class BaseRepository<T>: IGenericRepository<T> where T: IRootEntity
    {

		private readonly ServerlessDbContext _dbContext;
		
		protected IPocoDynamo Collection => _dbContext.Database;

		public BaseRepository(ServerlessDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<T> GetAll()
		{			
			return Collection.GetAll<T>();			
		}

		public IEnumerable<T> GetByIds(IEnumerable<int> ids)
		{
			return Collection.GetItems<T>(ids);
		}

		public T GetById(int id)
		{
			return Collection.GetItem<T>(id);
		}		

		public T Create(T entity)
		{
			entity.EnsureValid();
			return Collection.PutItem<T>(entity);
		}

		public T Update(T entity)
		{
			entity.EnsureValid();
			return Collection.PutItem<T>(entity);
		}

		public void Delete(int id)
		{
			_dbContext.Database.DeleteItem<T>(id);
		}

		
	}
}

