using Serverless.Application.Persistence;
using Serverless.Application.UseCaseSharedModels;

namespace Serverless.Application.UseCaseCommands.NewsStates
{
	public class CreateNewsStateCommandHandler: ICreateNewsStateCommandHandler
    {
		private readonly INewsStatesRepository _newsStatesRepository;
		//private readonly INewsContentRepository _newsContentRepository;

		public CreateNewsStateCommandHandler(
			//INewsContentRepository newsContentRepository,
			INewsStatesRepository newsStatesRepository)
		{
			//_newsContentRepository = newsContentRepository;
			_newsStatesRepository = newsStatesRepository;			
		}

		public NewsStatesModel Execute(CreateNewsStateCommand command) {
			var newsStateCommand = new Domain.News.NewsStates {
				Status = command.Status,
				NewsContentId = command.NewsContentId
			};
			_newsStatesRepository.Create(newsStateCommand);

			return new NewsStatesModel(newsStateCommand);
		}
	}
}
