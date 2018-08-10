using Microsoft.AspNetCore.Mvc;
using Serverless.Application.UseCaseCommands.NewsStates;
using Serverless.Application.UseCaseQueries.NewsStates;
using Serverless.Application.UseCaseSharedModels;
using System.Collections.Generic;

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
		public IEnumerable<NewsStatesModel> FindNewsList()
		{
			var list = _getNewsStatesQuery.FindAll();
			return list;
		}

		// GET api/news-states/5
		[HttpGet("{id}")]
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
