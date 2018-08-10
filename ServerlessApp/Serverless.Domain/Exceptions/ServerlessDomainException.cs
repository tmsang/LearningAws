using System;
using System.Collections.Generic;
using System.Linq;

namespace Serverless.Domain.Exceptions
{
    public class ServerlessDomainException: Exception
    {
        public List<string> Messages { get; set; }

        public ServerlessDomainException()
        {
            Messages = new List<string>();
        }

        public ServerlessDomainException(string message) {
            Messages = new List<string> { message };
        }

        public ServerlessDomainException(IEnumerable<string> messages)
        {
            Messages = messages.ToList();
        }
    }
}
