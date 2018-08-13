using Microsoft.AspNetCore.Mvc;
using Serverless.Application.UseCaseCommands.NewsStates;
using Serverless.Application.UseCaseQueries.NewsStates;
using Serverless.Application.UseCaseSharedModels;
using System.Collections.Generic;
using System.Linq;

namespace Serverless.Api.Controllers
{
	[Route("api/news-states")]
	public class NewsStateController: BaseController
    {
		private readonly IGetNewsStatesQuery _getNewsStatesQuery;
		private readonly ICreateNewsStateCommandHandler _createNewsStateCommandHandler;
		private readonly IUpdateNewsStateCommandHandler _updateNewsStateCommandHandler;
		private readonly IDeleteNewsStateCommandHandler _deleteNewsStateCommandHandler;		

		public NewsStateController(
			IGetNewsStatesQuery getNewsStatesQuery,
			ICreateNewsStateCommandHandler createNewsCommandHandler,
			IUpdateNewsStateCommandHandler updateNewsCommandHandler,
			IDeleteNewsStateCommandHandler deleteNewsCommandHandler)
		{
			_getNewsStatesQuery = getNewsStatesQuery;
			_createNewsStateCommandHandler = createNewsCommandHandler;
			_updateNewsStateCommandHandler = updateNewsCommandHandler;
			_deleteNewsStateCommandHandler = deleteNewsCommandHandler;			
		}

		// GET api/news-states
		[HttpGet]
		[Produces("application/xml")]
		public NewsStatesContainerModel FindNewsList()
		{
			IEnumerable<NewsStatesModel> newsStateModels = _getNewsStatesQuery.FindAll();
			return new NewsStatesContainerModel { NewsStatesModels = newsStateModels.ToList() };
		}

		// GET api/news-states/5
		[HttpGet("{id}")]
		[Produces("application/xml")]
		public NewsStatesModel FindNewsById(int id)
		{
			var news = _getNewsStatesQuery.FindById(id);
			return news;
		}














		// POST api/news-states
		[HttpPost]
		public IActionResult Post([FromBody]CreateNewsStateCommand createNewsStateCommand)
		{
			var result =_createNewsStateCommandHandler.Execute(createNewsStateCommand);
			return CreatedJsonResult(result);
		}

		// PUT api/news-states/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]UpdateNewsStateCommand updateNewsStateCommand)
		{
			_updateNewsStateCommandHandler.Execute(updateNewsStateCommand);
			return Ok();
		}

		// DELETE api/news-states/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_deleteNewsStateCommandHandler.Execute(id);
			return Ok();
		}
	}
}
