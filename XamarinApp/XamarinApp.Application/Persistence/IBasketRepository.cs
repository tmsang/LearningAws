using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinApp.Domain.Models.Basket;

namespace XamarinApp.Application.Persistence
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetByIdAsync(string customerId);
        IEnumerable<string> GetUsers();
        Task<CustomerBasket> UpdateAsync(CustomerBasket basket);
        Task<bool> DeleteAsync(string id);
    }
}
