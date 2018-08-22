using System.Threading.Tasks;
using XamarinApp.Domain.Models.Basket;

namespace XamarinApp.Application.UseCases.Basket
{
    public interface IBasketService
    {
        Task<CustomerBasket> GetByIdAsync(string customerId);
        Task<CustomerBasket> UpdateAsync(CustomerBasket basket);
        Task<bool> DeleteAsync(string id);
    }
}
