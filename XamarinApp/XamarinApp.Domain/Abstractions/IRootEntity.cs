namespace XamarinApp.Domain.Abstractions
{
    public interface IRootEntity : IEntity
    {
        bool Deleted { get; set; }
    }
}
