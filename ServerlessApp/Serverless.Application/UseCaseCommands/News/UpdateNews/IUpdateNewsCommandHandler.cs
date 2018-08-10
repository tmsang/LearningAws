using Serverless.Application.UseCaseSharedModels;

namespace Serverless.Application.UseCaseCommands.News
{
	public interface IUpdateNewsCommandHandler
	{
		NewsContentModel Execute(UpdateNewsCommand command);
	}
}
