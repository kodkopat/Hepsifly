using AutoMapper;
using Hepsifly.Core;
using Hepsifly.Domain;
using Hepsifly.Infrastructure.Automapper;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;

namespace Hepsifly.Infrastructure.Dependencies
{
    public static class Dependencies
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(mc => mc.AddProfile(new MappingProfile())).CreateMapper());
            services.AddSingleton(new MongoClient(Settings.Database.ConnectionString));
            services.AddHttpContextAccessor();
            services.AddScoped<CategoryBusiness>();
            services.AddScoped<ProductBusiness>();
            services.AddScoped<ReservationBusiness>();
            return services;
        }
    }
}
