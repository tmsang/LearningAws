namespace Serverless.Domain.ValueObjects
{
    public interface IBaseValueObject
    {
        ValidationResult Validate();
    }
}
