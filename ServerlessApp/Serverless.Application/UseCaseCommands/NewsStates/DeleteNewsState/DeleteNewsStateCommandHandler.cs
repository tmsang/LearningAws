using Serverless.Application.Persistence;
using Serverless.Application.UseCaseSharedModels;

namespace Serverless.Application.UseCaseCommands.NewsStates
{
	public class DeleteNewsStateCommandHandler: IDeleteNewsStateCommandHandler
    {
		private readonly INewsStatesRepository _newsStatesRepository;

		public DeleteNewsStateCommandHandler(INewsStatesRepository newsStatesRepository)
		{
			_newsStatesRepository = newsStatesRepository;
		}

		public void Execute(int id) {
			_newsStatesRepository.Delete(id);			
		}
		
	}
}
