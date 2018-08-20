using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinApp.Domain.Models.Catalog;

namespace XamarinApp.Application.Persistence
{
    public interface ICatalogRepository
    {
        Task<CatalogItem> GetByIdAsync(int id);
        Task<IEnumerable<CatalogItem>> GetByIdsAsync(IEnumerable<int> ids, int pageSize, int pageIndex);
        Task<IEnumerable<CatalogItem>> GetItemsByCatalogNameAsync(string catalogName, int pageSize, int pageIndex);

        Task<IEnumerable<CatalogItem>> GetItemsByCatalogTypeIdAsync(int catalogTypeId, int pageSize, int pageIndex);
        Task<IEnumerable<CatalogItem>> GetItemsByCatalogTypeIdAsync(int catalogTypeId, int catalogBrandId, int pageSize, int pageIndex);

        Task<IEnumerable<CatalogItem>> GetItemsByCatalogBrandIdAsync(int catalogBrandId, int pageSize, int pageIndex);
        Task<IEnumerable<CatalogItem>> GetItemsByPaginationAsync(int pageSize, int pageIndex);

        Task<IEnumerable<CatalogType>> GetCatalogTypesAsync();
        Task<IEnumerable<CatalogBrand>> GetCatalogBrandsAsync();

        Task<int> CreateAsync(CatalogItem catalogItem);
        Task UpdateAsync(int id, CatalogItem catalogItem);
        Task DeleteAsync(int id);
    }
}
