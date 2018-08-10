using System.Collections.Generic;

namespace Serverless.Application.Exceptions
{
	public class ServerlessApplicationNotFoundException: ServerlessApplicationException
    {
		public ServerlessApplicationNotFoundException()
		{
		}

		public ServerlessApplicationNotFoundException(string message) : base(message)
		{
		}

		public ServerlessApplicationNotFoundException(IEnumerable<string> messages) : base(messages)
		{
		}
	}
}
