using Microsoft.AspNetCore.Mvc;
using Serverless.Application.UseCaseCommands.News;
using Serverless.Application.UseCaseQueries.News;
using Serverless.Application.UseCaseSharedModels;
using System.Linq;

namespace Serverless.Api.Controllers
{
	[Route("api/news")]
	public class NewsController: BaseController
    {
		private readonly IGetNewsContentQuery _getNewsContentQuery;
		private readonly ICreateNewsCommandHandler _createNewsCommandHandler;
		private readonly IUpdateNewsCommandHandler _updateNewsCommandHandler;
		private readonly IDeleteNewsCommandHandler _deleteNewsCommandHandler;		

		public NewsController(
			IGetNewsContentQuery getNewsContentQuery,
			ICreateNewsCommandHandler createNewsCommandHandler,
			IUpdateNewsCommandHandler updateNewsCommandHandler,
			IDeleteNewsCommandHandler deleteNewsCommandHandler)
		{
			_getNewsContentQuery = getNewsContentQuery;
			_createNewsCommandHandler = createNewsCommandHandler;
			_updateNewsCommandHandler = updateNewsCommandHandler;
			_deleteNewsCommandHandler = deleteNewsCommandHandler;			
		}

		// GET api/news
		[HttpGet]
		[Produces("application/xml")]
		public NewsContainerModel GetNewsList()
		{
			var list = _getNewsContentQuery.FindAll();

			return new NewsContainerModel { NewsContentModels = list.ToList() };
		}

		// GET api/news/5
		[HttpGet("{id}")]
		[Produces("application/xml")]
		public NewsContentModel GetNews(int id)
		{
			var news = _getNewsContentQuery.FindById(id);

			return news;
		}














		// POST api/news
		[HttpPost]
		public IActionResult Post([FromBody]CreateNewsCommand createNewsCommand)
		{
			var result =_createNewsCommandHandler.Execute(createNewsCommand);
			return CreatedJsonResult(result);
		}

		// PUT api/news/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]UpdateNewsCommand updateNewsCommand)
		{
			_updateNewsCommandHandler.Execute(updateNewsCommand);
			return Ok();
		}

		// DELETE api/news/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_deleteNewsCommandHandler.Execute(id);
			return Ok();
		}
	}
}
