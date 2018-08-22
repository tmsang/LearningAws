using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinApp.Application.Persistence;
using XamarinApp.Domain.Models.Catalog;

namespace XamarinApp.Persistence.Catalog.Repositories
{
    public class CatalogRepository: ICatalogRepository
    {
        private readonly CatalogContext _catalogContext;

        public CatalogRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
            ((DbContext)catalogContext).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<CatalogItem> GetByIdAsync(int id) {
            var item = await _catalogContext.CatalogItems
                                .Include(p => p.CatalogType)
                                .Include(p => p.CatalogBrand)
                                .SingleOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<IEnumerable<CatalogItem>> GetByIdsAsync(IEnumerable<int> ids, int pageSize, int pageIndex)
        {
            var items = await _catalogContext.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .Where(ci => ids.Contains(ci.Id))
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<CatalogItem>> GetItemsByCatalogNameAsync(string catalogName, int pageSize, int pageIndex)
        {
            var items = await _catalogContext.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .Where(c => c.Name.StartsWith(catalogName))
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<CatalogItem>> GetItemsByCatalogTypeIdAsync(int catalogTypeId, int pageSize, int pageIndex)
        {
            var items = await _catalogContext.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .Where(p => p.CatalogTypeId == catalogTypeId)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<CatalogItem>> GetItemsByCatalogTypeIdAsync(int catalogTypeId, int catalogBrandId, int pageSize, int pageIndex)
        {
            var items = await _catalogContext.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .Where(p => p.CatalogTypeId == catalogTypeId && p.CatalogBrandId == catalogBrandId)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<CatalogItem>> GetItemsByCatalogBrandIdAsync(int catalogBrandId, int pageSize, int pageIndex)
        {
            var items = await _catalogContext.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .Where(p => p.CatalogBrandId == catalogBrandId)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<CatalogItem>> GetItemsByPaginationAsync(int pageSize, int pageIndex)
        {
            var items = await _catalogContext.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<CatalogType>> GetCatalogTypesAsync()
        {
            var items = await _catalogContext.CatalogTypes
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<CatalogBrand>> GetCatalogBrandsAsync()
        {
            var items = await _catalogContext.CatalogBrands
                .ToListAsync();

            return items;
        }

        public async Task<int> CreateAsync(CatalogItem catalogItem)
        {
            var item = new CatalogItem
            {
                CatalogBrandId = catalogItem.CatalogBrandId,
                CatalogTypeId = catalogItem.CatalogTypeId,
                Description = catalogItem.Description,
                Name = catalogItem.Name,
                PictureFileName = catalogItem.PictureFileName,
                Price = catalogItem.Price
            };
            _catalogContext.CatalogItems.Add(item);

            await _catalogContext.SaveChangesAsync();

            return item.Id;
        }

        public async Task UpdateAsync(int id, CatalogItem catalogItem)
        {
            var product = _catalogContext.CatalogItems.SingleOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new Exception("Catalog Id was not found");
            }

            _catalogContext.CatalogItems.Remove(product);

            await _catalogContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = _catalogContext.CatalogItems.SingleOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new Exception("Catalog Id was not found");
            }

            _catalogContext.CatalogItems.Remove(product);

            await _catalogContext.SaveChangesAsync();
        }
    }
}
