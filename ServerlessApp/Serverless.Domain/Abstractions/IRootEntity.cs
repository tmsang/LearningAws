namespace Serverless.Domain.Abstractions
{
    public interface IRootEntity: IEntity
    {
        bool Deleted { get; set; }
    }
}
