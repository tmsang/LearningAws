using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XamarinApp.Application.UseCases.Basket;
using XamarinApp.Application.UseCases.Identity;
using XamarinApp.Domain.Models.Basket;

namespace XamarinApp.WebAPI.Controllers
{
    [Route("api/basket")]
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IIdentityService _identityService;
        //private readonly IEventBus _eventBus;

        public BasketController(IBasketService basketService,
            IIdentityService identityService)
        {
            _basketService = basketService;
            _identityService = identityService;
            //_eventBus = eventBus;
        }

        // GET api/basket/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var basket = await _basketService.GetByIdAsync(id);
            if (basket == null)
            {
                return Ok(new CustomerBasket(id) { });
            }

            return Ok(basket);
        }

        // POST api/basket
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CustomerBasket value)
        {
            var basket = await _basketService.UpdateAsync(value);

            return Ok(basket);
        }

        // POST api/basket/checkout
        [Route("checkout")]
        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody]BasketCheckout basketCheckout, [FromHeader(Name = "x-requestid")] string requestId)
        {
            var userId = _identityService.GetUserIdentity();

            basketCheckout.RequestId = (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty) ?
                guid : basketCheckout.RequestId;

            var basket = await _basketService.GetByIdAsync(userId);
            if (basket == null)
            {
                return BadRequest();
            }

            var userName = User.FindFirst(x => x.Type == "unique_name").Value;

            //var eventMessage = new UserCheckoutAcceptedIntegrationEvent(userId, userName, basketCheckout.City, basketCheckout.Street,
            //    basketCheckout.State, basketCheckout.Country, basketCheckout.ZipCode, basketCheckout.CardNumber, basketCheckout.CardHolderName,
            //    basketCheckout.CardExpiration, basketCheckout.CardSecurityNumber, basketCheckout.CardTypeId, basketCheckout.Buyer, basketCheckout.RequestId, basket);

            // Once basket is checkout, sends an integration event to
            // ordering.api to convert basket to order and proceeds with
            // order creation process
            //_eventBus.Publish(eventMessage);

            return Accepted();
        }

        // DELETE api/basket/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _basketService.DeleteAsync(id);
        }

    }
}
