﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XamarinApp.Domain.Configurations;

namespace XamarinApp.WebAPI.Extensions
{
    public static class AddCustomOptionsExtension
    {
        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CatalogSettings>(configuration);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "Please refer to the errors property for additional details."
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });

            return services;
        }
    }
}
