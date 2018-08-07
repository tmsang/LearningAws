using System.Collections.Generic;

namespace Serverless.Catalog.Api.Services.CatalogItem
{
    public interface ICatalogItemService
    {
        List<CatalogItemDto> GetAll();
        CatalogItemDto Get(int id);
        void Insert(CatalogItemDto newValue);
        void Update(int id, CatalogItemDto newValue);
        void Delete(int id);
    }
}
