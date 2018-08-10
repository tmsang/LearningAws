using Serverless.Application.Persistence;

namespace Serverless.Application.UseCaseCommands.News
{
	public class DeleteNewsCommandHandler: IDeleteNewsCommandHandler
    {
		private readonly INewsContentRepository _newsContentRepository;

		public DeleteNewsCommandHandler(INewsContentRepository newsContentRepository)
		{
			_newsContentRepository = newsContentRepository;
		}

		public void Execute(int id) {
			_newsContentRepository.Delete(id);			
		}
		
	}
}
