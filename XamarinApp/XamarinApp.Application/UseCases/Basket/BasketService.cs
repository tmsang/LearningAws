using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using XamarinApp.Application.Persistence;
using XamarinApp.Domain.Models.Basket;

namespace XamarinApp.Application.UseCases.Basket
{
    public class BasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<CustomerBasket> GetByIdAsync(string customerId)
        {
            return await _basketRepository.GetByIdAsync(customerId);
        }

        public async Task<CustomerBasket> UpdateAsync(CustomerBasket basket)
        {
            return await _basketRepository.UpdateAsync(basket);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _basketRepository.DeleteAsync(id);
        }
    }
}
