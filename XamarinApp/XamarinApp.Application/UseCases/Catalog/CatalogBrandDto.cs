using XamarinApp.Domain.Models.Catalog;

namespace XamarinApp.Application.UseCases.Catalog
{
    public class CatalogBrandDto
    {
        public CatalogBrandDto(CatalogBrand catalogBrand)
        {
            Id = catalogBrand.Id;
            Brand = catalogBrand.Brand;
        }

        public int Id { get; set; }

        public string Brand { get; set; }
    }
}
