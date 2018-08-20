using XamarinApp.Domain.Models.Catalog;

namespace XamarinApp.Application.UseCases.Catalog
{
    public class CatalogItemDto
    {
        public CatalogItemDto(CatalogItem catalogItem)
        {
            Id = catalogItem.Id;
            Name = catalogItem.Name;
            Description = catalogItem.Description;
            Price = catalogItem.Price;
            PictureFileName = catalogItem.PictureFileName;
            PictureUri = catalogItem.PictureUri;

            CatalogTypeId = catalogItem.CatalogTypeId;
            CatalogType = new CatalogTypeDto(catalogItem.CatalogType);

            CatalogBrandId = catalogItem.CatalogBrandId;
            CatalogBrand = new CatalogBrandDto(catalogItem.CatalogBrand);

            AvailableStock = catalogItem.AvailableStock;
            RestockThreshold = catalogItem.RestockThreshold;
            MaxStockThreshold = catalogItem.MaxStockThreshold;
            OnReorder = catalogItem.OnReorder;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }

        public int CatalogTypeId { get; set; }

        public CatalogTypeDto CatalogType { get; set; }

        public int CatalogBrandId { get; set; }

        public CatalogBrandDto CatalogBrand { get; set; }

        // Quantity in stock
        public int AvailableStock { get; set; }

        // Available stock at which we should reorder
        public int RestockThreshold { get; set; }


        // Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
        public int MaxStockThreshold { get; set; }

        /// <summary>
        /// True if item is on reorder
        /// </summary>
        public bool OnReorder { get; set; }
    }
}
