using Serverless.Domain.ValueObjects;
using System.Collections.Generic;

namespace Serverless.Domain.Abstractions
{
    public abstract class BaseEntity
    {
        protected abstract string GetId();

        public virtual ValidationResult Validate() {
            var errorMessages = new List<string>();
            if (string.IsNullOrEmpty(GetId())) errorMessages.Add($"{GetType().Name} Id is invalid");

            return new ValidationResult(errorMessages);
        }

        public void EnsureValid() {
            Validate().EnsureValid();
        }
    }
}
