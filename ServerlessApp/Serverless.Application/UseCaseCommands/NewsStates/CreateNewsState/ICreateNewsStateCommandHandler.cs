using Serverless.Application.UseCaseSharedModels;

namespace Serverless.Application.UseCaseCommands.NewsStates
{
	public interface ICreateNewsStateCommandHandler
    {
		NewsStatesModel Execute(CreateNewsStateCommand command);
	}
}
