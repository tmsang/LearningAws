using MediatR;
using XamarinApp.Domain.Models.Ordering.OrderAggregate;

namespace XamarinApp.Domain.Events
{
    public class OrderShippedDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderShippedDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
