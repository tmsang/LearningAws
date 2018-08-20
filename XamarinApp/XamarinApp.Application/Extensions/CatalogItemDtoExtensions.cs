using XamarinApp.Application.UseCases.Catalog;

namespace XamarinApp.Application.Extensions
{
    public static class CatalogItemDtoExtensions
    {
        public static void FillProductUrl(this CatalogItemDto item, string picBaseUrl, bool azureStorageEnabled)
        {
            if (item != null)
            {
                item.PictureUri = azureStorageEnabled
                   ? picBaseUrl + item.PictureFileName
                   : picBaseUrl.Replace("[0]", item.Id.ToString());
            }
        }
    }
}
