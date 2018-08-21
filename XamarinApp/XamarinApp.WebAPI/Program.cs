using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using XamarinApp.Domain.Configurations;
using XamarinApp.Persistence.Catalog;
using XamarinApp.WebAPI.Extensions;

namespace XamarinApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            BuildWebHost(args)
                .MigrateDbContext<CatalogContext>((context, services) => {
                    var env = services.GetService<IHostingEnvironment>();
                    var settings = services.GetService<IOptions<CatalogSettings>>();
                    var logger = services.GetService<ILogger<CatalogContextSeed>>();

                    new CatalogContextSeed()
                    .SeedAsync(context, env, settings, logger)
                    .Wait();
                })
                .Run();
        }

        private static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseWebRoot("Pics")
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    var builtConfig = config.Build();

                    var configurationBuilder = new ConfigurationBuilder();

                    if (Convert.ToBoolean(builtConfig["UseVault"]))
                    {
                        configurationBuilder.AddAzureKeyVault(
                            $"https://{builtConfig["Vault:Name"]}.vault.azure.net/",
                            builtConfig["Vault:ClientId"],
                            builtConfig["Vault:ClientSecret"]);
                    }

                    configurationBuilder.AddEnvironmentVariables();

                    config.AddConfiguration(configurationBuilder.Build());
                })
                .ConfigureLogging((hostingContext, builder) =>
                {
                    builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    builder.AddConsole();
                    builder.AddDebug();
                })
                .Build();
        }



        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
    }
}
