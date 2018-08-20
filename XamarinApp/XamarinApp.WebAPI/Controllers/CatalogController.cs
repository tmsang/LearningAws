using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XamarinApp.Application.UseCases.Catalog;

namespace XamarinApp.WebAPI.Controllers
{
    [Route("api/catalog")]
    public class CatalogController: ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        // GET api/catalog/items[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> GetItems([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, [FromQuery] string ids = null)
        {
            var items = await _catalogService.GetByIdsAsync(ids, pageSize, pageIndex);
            return Ok(items);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetItem(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _catalogService.GetByIdAsync(id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        // GET api/catalog/items/withname/samplename[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("items/withname/{name:minlength(1)}")]
        public async Task<IActionResult> GetItemsByCatalogName(string name, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var items = await _catalogService.GetItemsByCatalogNameAsync(name, pageSize, pageIndex);
            return Ok(items);
        }

        // GET api/catalog/items/type/1/brand[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("items/type/{catalogTypeId}/brand/{catalogBrandId:int?}")]
        public async Task<IActionResult> GetItemsByCatalogType(int catalogTypeId, int? catalogBrandId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var items = await _catalogService.GetItemsByCatalogTypeIdAsync(catalogTypeId, catalogBrandId, pageSize, pageIndex);
            return Ok(items);
        }

        // GET api/catalog/items/type/all/brand[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("items/type/all/brand/{catalogBrandId:int?}")]
        public async Task<IActionResult> GetItemsByCatalogBrand(int? catalogBrandId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var items = await _catalogService.GetItemsByCatalogBrandIdAsync(catalogBrandId, pageSize, pageIndex);
            return Ok(items);
        }

        // GET api/catalog/catalog-types
        [HttpGet]
        [Route("catalog-types")]
        public async Task<IActionResult> CatalogTypes()
        {
            var items = await _catalogService.GetCatalogTypesAsync();
            return Ok(items);
        }

        // GET api/catalog/catalog-brands
        [HttpGet]
        [Route("catalog-brands")]
        public async Task<IActionResult> CatalogBrands()
        {
            var items = await _catalogService.GetCatalogBrandsAsync();
            return Ok(items);
        }

        //POST api/catalog/items
        [Route("items")]
        [HttpPost]
        public async Task<IActionResult> CreateCatalogItem([FromBody]CatalogItemDto catalogItemDto)
        {
            await _catalogService.CreateAsync(catalogItemDto);
            return CreatedAtAction("CatalogServiceUpdateAsync", new { id = catalogItemDto.Id }, null);
        }

        //PUT api/catalog/items
        [Route("items")]
        [HttpPut]
        public async Task<IActionResult> UpdateCatalogItem(int id, [FromBody]CatalogItemDto catalogItemDto)
        {
            await _catalogService.UpdateAsync(id, catalogItemDto);
            return Ok();
        }

        //DELETE api/catalog/id
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCatalogItem(int id)
        {
            await _catalogService.DeleteAsync(id);
            return NoContent();
        }

    }
}
