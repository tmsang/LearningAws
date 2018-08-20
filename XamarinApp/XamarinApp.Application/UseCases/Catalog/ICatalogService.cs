using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinApp.Application.UseCases.Catalog
{
    public interface ICatalogService
    {
        Task<CatalogItemDto> GetByIdAsync(int id);
        Task<IEnumerable<CatalogItemDto>> GetByIdsAsync(string ids, int? pageSize, int? pageIndex);
        Task<IEnumerable<CatalogItemDto>> GetItemsByCatalogNameAsync(string catalogName, int? pageSize, int? pageIndex);
        Task<IEnumerable<CatalogItemDto>> GetItemsByCatalogTypeIdAsync(int catalogTypeId, int? catalogBrandId, int? pageSize, int? pageIndex);
        Task<IEnumerable<CatalogItemDto>> GetItemsByCatalogBrandIdAsync(int? catalogBrandId, int pageSize, int pageIndex);

        Task<IEnumerable<CatalogTypeDto>> GetCatalogTypesAsync();
        Task<IEnumerable<CatalogBrandDto>> GetCatalogBrandsAsync();

        Task<int> CreateAsync(CatalogItemDto catalogItemDto);
        Task UpdateAsync(int id, CatalogItemDto catalogItemDto);
        Task DeleteAsync(int id);
    }
}
