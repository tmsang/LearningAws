using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serverless.Application;
using Serverless.Common;
using Serverless.Persistence.Dynamo;

namespace Serverless.Api
{
	public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

		public IContainer ApplicationContainer { get; private set; }
		public static IConfiguration Configuration { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container
		// ConfigureServices is where you register dependencies. This gets
		// called by the runtime before the Configure method, below.
		public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();

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

			//builder.RegisterModule<ServerlessCommonModule>();
			builder.RegisterModule<ServerlessPersistenceDynamoModule>();
			builder.RegisterModule<ServerlessApplicationModule>();
			builder.Populate(services);

			ApplicationContainer = builder.Build();
			return new AutofacServiceProvider(ApplicationContainer);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
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

			//Configure logs
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
