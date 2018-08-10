using System;
using System.Collections.Generic;
using System.Linq;

namespace Serverless.Application.Exceptions
{
	public class ServerlessApplicationException: Exception
    {
		public ServerlessApplicationException()
		{
			Messages = new List<string>();
		}

		public ServerlessApplicationException(string message) : base(message)
		{
			Messages = new List<string> { message };
		}

		public ServerlessApplicationException(IEnumerable<string> messages)
		{
			Messages = messages.ToList();
		}

		public List<string> Messages { get; set; }
	}
}
