using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using XamarinApp.Domain.Models.Catalog;
using XamarinApp.Persistence.Catalog.EntityConfigurations;

namespace XamarinApp.Persistence.Catalog
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {

        }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
        }
    }


    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
            //    .UseSqlServer("Server=.;Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb;Integrated Security=true");

            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
                //.UseSqlite(@"Data Source = D:\Projects\Learning\XamarinApp\XamarinApp.Persistence.Catalog\Database\eShop.db");
                .UseSqlServer("Server=localhost\\SQLEXPRESS01;Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb;Integrated Security=true");


            return new CatalogContext(optionsBuilder.Options);
        }
    }
}
