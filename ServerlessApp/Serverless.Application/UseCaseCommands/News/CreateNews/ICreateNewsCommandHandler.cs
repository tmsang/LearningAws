using Serverless.Application.UseCaseSharedModels;

namespace Serverless.Application.UseCaseCommands.News
{
	public interface ICreateNewsCommandHandler
    {
		NewsContentModel Execute(CreateNewsCommand command);
    }
}
