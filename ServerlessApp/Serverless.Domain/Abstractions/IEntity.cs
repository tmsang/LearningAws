using Serverless.Domain.ValueObjects;

namespace Serverless.Domain.Abstractions
{
    public interface IEntity
    {
        int Id { get; set; }
        ValidationResult Validate();
        void EnsureValid();
    }
}
