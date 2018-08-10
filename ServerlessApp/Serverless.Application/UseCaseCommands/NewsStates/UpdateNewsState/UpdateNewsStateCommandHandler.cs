using Serverless.Application.Persistence;
using Serverless.Application.UseCaseSharedModels;

namespace Serverless.Application.UseCaseCommands.NewsStates
{
	public class UpdateNewsStateCommandHandler: IUpdateNewsStateCommandHandler
    {
		private readonly INewsStatesRepository _newsStatesRepository;
		//private readonly INewsContentRepository _newsContentRepository;

		public UpdateNewsStateCommandHandler(
			//INewsContentRepository newsContentRepository,
			INewsStatesRepository newsStatesRepository)
		{
			//_newsContentRepository = newsContentRepository;
			_newsStatesRepository = newsStatesRepository;			
		}

		public NewsStatesModel Execute(UpdateNewsStateCommand command) {
			var newsStateCommand = new Domain.News.NewsStates {
				Id = command.Id,
				Status = command.Status,
				NewsContentId = command.NewsContentId
			};
			_newsStatesRepository.Update(newsStateCommand);

			return new NewsStatesModel(newsStateCommand);
		}
	}
}
