using MediatR;
using XamarinApp.Domain.Models.Ordering.OrderAggregate;

namespace XamarinApp.Domain.Events
{
    public class OrderCancelledDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderCancelledDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
