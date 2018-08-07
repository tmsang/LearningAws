﻿using ServiceStack.DataAnnotations;

namespace Serverless.Catalog.Api.Models
{
    public class CatalogItem
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }
    }
}
