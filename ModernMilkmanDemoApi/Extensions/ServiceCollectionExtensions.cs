﻿using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ModernMilkmanDemoApi.Core.Data;
using ModernMilkmanDemoApi.Core.Validators;
using System;
using System.IO;
using System.Reflection;

namespace ModernMilkmanDemo.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommandsAndQueries(this IServiceCollection services)
        {
            services.AddProblemDetails(x =>
            {
                //x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                //x.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
            });

            return services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>))
                .AddMediatR(typeof(Repository));
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services
               .AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebHooks Processor API", Version = "V1" });
                   var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                   c.IncludeXmlComments(xmlPath);
               });
        }
        public static IServiceCollection AddApiVersionConfig(this IServiceCollection services)
        {
            return services
                .AddApiVersioning(option =>
                {
                    option.ReportApiVersions = true;
                    option.AssumeDefaultVersionWhenUnspecified = true;
                    option.DefaultApiVersion = new ApiVersion(1, 0);
                    option.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
                })
                .AddVersionedApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.AssumeDefaultVersionWhenUnspecified = true;
                });
        }

        public static IServiceCollection AddData(this IServiceCollection services)
        {
            return services
                    .AddScoped<IRepository, Repository>()
                    .AddDbContext<DemoContext>(options =>
                        options
                            .UseLazyLoadingProxies()
                            .UseInMemoryDatabase(databaseName: "DemoDatabase"
                    ));
        }
    }
}
