using XamarinApp.Domain.Models.Catalog;

namespace XamarinApp.Application.UseCases.Catalog
{
    public class CatalogTypeDto
    {
        public CatalogTypeDto(CatalogType catalogType)
        {
            Id = catalogType.Id;
            Type = catalogType.Type;
        }

        public int Id { get; set; }

        public string Type { get; set; }
    }
}
