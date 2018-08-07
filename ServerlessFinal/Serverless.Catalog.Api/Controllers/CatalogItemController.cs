using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Serverless.Catalog.Api.Configurations;
using Serverless.Catalog.Api.Services.CatalogItem;

namespace Serverless.Catalog.Api.Controllers
{
    [Route("api/catalog-items")]
    public class CatalogItemController : Controller
    {
        private ICatalogItemService _catalogItemService;

        public CatalogItemController() {
            _catalogItemService = ContainerIoC.Resolve<ICatalogItemService>();            
        }

        [HttpGet]
        public List<CatalogItemDto> GetCatalogItems()
        {
            return _catalogItemService.GetAll();            
        }

        // GET api/catalog-items/5
        [HttpGet("{id}")]
        public CatalogItemDto Get(int id)
        {
            return _catalogItemService.Get(id);
        }

        // POST api/catalog-items
        [HttpPost]
        public void Post([FromBody]CatalogItemDto newValue)
        {
            _catalogItemService.Insert(newValue);
        }

        // PUT api/catalog-items/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CatalogItemDto newValue)
        {
            _catalogItemService.Update(id, newValue);
        }

        // DELETE api/catalog-items/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _catalogItemService.Delete(id);
        }
    }
}
