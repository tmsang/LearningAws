using Serverless.Domain.Exceptions;

namespace Serverless.Domain.ValueObjects
{
	public abstract class BaseValueObject
    {
		public virtual ValidationResult Validate() {
			return new ValidationResult();
		}

		public void EnsureValid() {
			var validationResult = Validate();
			if (!validationResult.IsValid) throw new ServerlessDomainException(validationResult.ErrorMessages);
		}
    }
}
