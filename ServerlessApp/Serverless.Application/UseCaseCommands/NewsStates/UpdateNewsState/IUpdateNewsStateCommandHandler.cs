using Serverless.Application.UseCaseSharedModels;

namespace Serverless.Application.UseCaseCommands.NewsStates
{
	public interface IUpdateNewsStateCommandHandler
    {
		NewsStatesModel Execute(UpdateNewsStateCommand command);
	}
}
