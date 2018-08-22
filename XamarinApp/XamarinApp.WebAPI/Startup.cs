using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using XamarinApp.Application;
using XamarinApp.Domain.Configurations;
using XamarinApp.Persistence.Basket;
using XamarinApp.Persistence.Catalog;
using XamarinApp.WebAPI.Extensions;

namespace XamarinApp.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomMVC(Configuration)
                .AddCustomDbContext(Configuration)
                .AddCustomOptions(Configuration)
                .AddCustomSwagger();

            services.AddCustomAuthentication(Configuration);
            services.AddCustomRedis(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policyBuilder => policyBuilder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddOptions();

            //==============================================================
            // Register IOC
            //==============================================================
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            //
            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.

            builder.RegisterModule<XamarinPersistenceCatalogModule>();
            builder.RegisterModule<XamarinPersistenceBasketModule>();
            builder.RegisterModule<XamarinAppicationModule>();

            builder.Populate(services);
            SharedItems.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(SharedItems.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");
            app.UseCustomAuthentication(this.Configuration);

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCustomSwagger(Configuration, loggerFactory);

            app.SeedLocationAsync(loggerFactory);
        }
    }
}
