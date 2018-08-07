using System.Collections.Generic;

namespace SeverlessFinal1.Services.CatalogItem
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
