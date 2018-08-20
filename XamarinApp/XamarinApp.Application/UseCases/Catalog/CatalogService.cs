using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinApp.Application.Extensions;
using XamarinApp.Application.Persistence;
using XamarinApp.Domain.Configurations;
using XamarinApp.Domain.Models.Catalog;

namespace XamarinApp.Application.UseCases.Catalog
{
    public class CatalogService: ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly CatalogSettings _settings;

        public CatalogService(ICatalogRepository catalogRepository,
            IOptionsSnapshot<CatalogSettings> settings)
        {
            _catalogRepository = catalogRepository;
            _settings = settings.Value;
        }

        public async Task<CatalogItemDto> GetByIdAsync(int id)
        {
            var item = await _catalogRepository.GetByIdAsync(id);

            var baseUri = _settings.PicBaseUrl;
            var azureStorageEnabled = _settings.AzureStorageEnabled;
            var itemDto = new CatalogItemDto(item);
            itemDto.FillProductUrl(baseUri, azureStorageEnabled: azureStorageEnabled);

            return itemDto;
        }

        public async Task<IEnumerable<CatalogItemDto>> GetByIdsAsync(string ids, int? pageSize, int? pageIndex)
        {
            var numIds = ids.Split(',').Select(id => (Ok: int.TryParse(id, out int x), Value: x));

            if (!numIds.All(nid => nid.Ok))
            {
                throw new Exception("ids value invalid. Must be comma-separated list of numbers");
            }

            var idsToSelect = numIds.Select(id => id.Value);
            var items = await _catalogRepository.GetByIdsAsync(idsToSelect, pageSize ?? CatalogConstant.PageSize, pageIndex ?? CatalogConstant.PageIndex);

            return ChangeUriPlaceholder(items);
        }

        public async Task<IEnumerable<CatalogItemDto>> GetItemsByCatalogNameAsync(string catalogName, int? pageSize, int? pageIndex)
        {
            var items = await _catalogRepository.GetItemsByCatalogNameAsync(catalogName, pageSize ?? CatalogConstant.PageSize, pageIndex ?? CatalogConstant.PageIndex);
            return ChangeUriPlaceholder(items);
        }

        public async Task<IEnumerable<CatalogItemDto>> GetItemsByCatalogTypeIdAsync(int catalogTypeId, int? catalogBrandId, int? pageSize, int? pageIndex)
        {
            dynamic items;
            if (catalogBrandId != null)
            {
                items = await _catalogRepository.GetItemsByCatalogTypeIdAsync(catalogTypeId, (int)catalogBrandId, pageSize ?? CatalogConstant.PageSize, pageIndex ?? CatalogConstant.PageIndex);
            }
            else {
                items = await _catalogRepository.GetItemsByCatalogTypeIdAsync(catalogTypeId, pageSize ?? CatalogConstant.PageSize, pageIndex ?? CatalogConstant.PageIndex);
            }
            return ChangeUriPlaceholder(items);
        }

        public async Task<IEnumerable<CatalogItemDto>> GetItemsByCatalogBrandIdAsync(int? catalogBrandId, int pageSize, int pageIndex)
        {
            dynamic items;
            if (catalogBrandId != null)
            {
                items = await _catalogRepository.GetItemsByCatalogBrandIdAsync((int)catalogBrandId, pageSize, pageIndex);
            }
            else
            {
                items = await _catalogRepository.GetItemsByPaginationAsync(pageSize, pageIndex);
            }
            return ChangeUriPlaceholder(items);
        }

        public async Task<IEnumerable<CatalogTypeDto>> GetCatalogTypesAsync()
        {
            var items = await _catalogRepository.GetCatalogTypesAsync();
            return items.Select(p => new CatalogTypeDto(p));
        }

        public async Task<IEnumerable<CatalogBrandDto>> GetCatalogBrandsAsync()
        {
            var items = await _catalogRepository.GetCatalogBrandsAsync();
            return items.Select(p => new CatalogBrandDto(p));
        }

        public async Task<int> CreateAsync(CatalogItemDto catalogItemDto)
        {
            var item = new CatalogItem
            {
                Name = catalogItemDto.Name,
                Description = catalogItemDto.Description,
                Price = catalogItemDto.Price,
                PictureFileName = catalogItemDto.PictureFileName,
                PictureUri = catalogItemDto.PictureUri,

                CatalogTypeId = catalogItemDto.CatalogTypeId,
                CatalogBrandId = catalogItemDto.CatalogBrandId,

                //TODO: double check business by system updated
                AvailableStock = catalogItemDto.AvailableStock,
                RestockThreshold = catalogItemDto.RestockThreshold,
                MaxStockThreshold = catalogItemDto.MaxStockThreshold,
                OnReorder = catalogItemDto.OnReorder
            };
            await _catalogRepository.CreateAsync(item);

            return item.Id;
        }

        public async Task UpdateAsync(int id, CatalogItemDto catalogItemDto)
        {
            var catalogItem = await _catalogRepository.GetByIdAsync(id);
            if (catalogItem == null) {
                throw new Exception("Catalog Id was not found");
            }

            catalogItem.Name = catalogItemDto.Name;
            catalogItem.Description = catalogItemDto.Description;
            catalogItem.Price = catalogItemDto.Price;
            catalogItem.PictureFileName = catalogItemDto.PictureFileName;
            catalogItem.PictureUri = catalogItemDto.PictureUri;

            catalogItem.CatalogTypeId = catalogItemDto.CatalogTypeId;
            catalogItem.CatalogBrandId = catalogItemDto.CatalogBrandId;

            //TODO: double check business by system updated
            catalogItem.AvailableStock = catalogItemDto.AvailableStock;
            catalogItem.RestockThreshold = catalogItemDto.RestockThreshold;
            catalogItem.MaxStockThreshold = catalogItemDto.MaxStockThreshold;
            catalogItem.OnReorder = catalogItemDto.OnReorder;

            await _catalogRepository.UpdateAsync(id, catalogItem);
        }

        public async Task DeleteAsync(int id)
        {
            var catalogItem = await _catalogRepository.GetByIdAsync(id);
            if (catalogItem == null)
            {
                throw new Exception("Catalog Id was not found");
            }

            await _catalogRepository.DeleteAsync(id);
        }


        private List<CatalogItemDto> ChangeUriPlaceholder(IEnumerable<CatalogItem> items)
        {
            var baseUri = _settings.PicBaseUrl;
            var azureStorageEnabled = _settings.AzureStorageEnabled;

            var result = items.Select(p => {
                var itemDto = new CatalogItemDto(p);
                itemDto.FillProductUrl(baseUri, azureStorageEnabled: azureStorageEnabled);

                return itemDto;
            });

            return result.ToList();
        }
    }
}
