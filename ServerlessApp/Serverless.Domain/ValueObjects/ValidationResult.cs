using Serverless.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Serverless.Domain.ValueObjects
{
    public class ValidationResult: IBaseValueObject
    {
        public List<string> ErrorMessages { get; set; }
        public bool IsValid => ErrorMessages == null || !ErrorMessages.Any();

        public ValidationResult() {
            ErrorMessages = new List<string>();
        }

        public ValidationResult(string errorMessage)
        {
            ErrorMessages = new List<string> { errorMessage };
        }

        public ValidationResult(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages.ToList();
        }


        public void AddErrorMessage(string errorMessage) {
            ErrorMessages.Add(errorMessage);
        }

        public void AddErrorMessage(IEnumerable<string> errorMessages) {
            ErrorMessages.AddRange(errorMessages);
        }

        public void EnsureValid() {
            if (!IsValid) throw new ServerlessDomainException(ErrorMessages);
        }

        public ValidationResult Validate() {
            return new ValidationResult();
        }

    }
}
