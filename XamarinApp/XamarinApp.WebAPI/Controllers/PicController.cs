using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XamarinApp.Application.UseCases.Catalog;

namespace XamarinApp.WebAPI.Controllers
{
    public class PicController: Controller
    {
        private readonly ICatalogService _catalogService;

        public PicController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        [Route("api/catalog/items/{catalogItemId:int}/pic")]
        public async Task<IActionResult> GetImage(int catalogItemId)
        {
            if (catalogItemId <= 0)
            {
                return BadRequest();
            }

            var item = await _catalogService.GetImageFile(catalogItemId);
            var buffer = item.Item1;
            var mimeType = item.Item2;

            if (buffer != null && !string.IsNullOrEmpty(mimeType))
            {
                return File(buffer, mimeType);
            }

            return NotFound();
        }
    }
}
