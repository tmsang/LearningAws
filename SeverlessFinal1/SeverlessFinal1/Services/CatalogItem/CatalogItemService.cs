using ServiceStack.Aws.DynamoDb;
using SeverlessFinal1.Services.Common;
using System.Collections.Generic;
using System.Linq;

namespace SeverlessFinal1.Services.CatalogItem
{
    public class CatalogItemService: ICatalogItemService
    {        
        public CatalogItemService()
        {            
            
        }

        public List<CatalogItemDto> GetAll()
        {
            var catalogDTOs = PocoDynamoDBFactory.Database.GetAll<Models.CatalogItem>().Select(p => ParseIntoCatalogItem(p)).ToList();

            return catalogDTOs;
        }

        public CatalogItemDto Get(int id) {
            var catalogDto = PocoDynamoDBFactory.Database.GetItem<Models.CatalogItem>(id);
            return ParseIntoCatalogItem(catalogDto);
        }

        private CatalogItemDto ParseIntoCatalogItem(Models.CatalogItem catalogItem) {
            return new CatalogItemDto
            {
                Id = catalogItem.Id,
                Name = catalogItem.Name,
                Description = catalogItem.Description,
                Price = catalogItem.Price,
                PictureFileName = catalogItem.PictureFileName,
                PictureUri = catalogItem.PictureUri
            };
        }

        private Models.CatalogItem ParseIntoCatalogItemDto(CatalogItemDto catalogItemDto)
        {
            return new Models.CatalogItem
            {
                Id = catalogItemDto.Id,
                Name = catalogItemDto.Name,
                Description = catalogItemDto.Description,
                Price = catalogItemDto.Price,
                PictureFileName = catalogItemDto.PictureFileName,
                PictureUri = catalogItemDto.PictureUri
            };
        }

        public void Insert(CatalogItemDto newValue)
        {
            var todo = ParseIntoCatalogItemDto(newValue);
            PocoDynamoDBFactory.Database.PutItem(todo);            
        }

        public void Update(int id, CatalogItemDto newValue)
        {
            var savedTodo = PocoDynamoDBFactory.Database.GetItem<Models.CatalogItem>(id);
            savedTodo.Name = newValue.Name;
            savedTodo.Description = newValue.Description;
            savedTodo.Price = newValue.Price;
            savedTodo.PictureFileName = newValue.PictureFileName;
            savedTodo.PictureUri = newValue.PictureUri;

            PocoDynamoDBFactory.Database.PutItem(savedTodo);
        }

        public void Delete(int id)
        {
            PocoDynamoDBFactory.Database.DeleteItem<Models.CatalogItem>(id);
        }
    }
}
