using Hepsifly.Infrastructure.Dependencies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Hepsifly.Core;

namespace Hepsifly.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hepsifly.API", Version = "v1" });
            });

            services.AddAppDependencies();
            services.AddMemoryCache();
            services.AddStackExchangeRedisCache(c =>
            {
                c.Configuration = $"{Settings.Redis.Host}:{Settings.Redis.Port}";
                c.InstanceName = "master";
            });
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hepsifly.API v1"));
            }

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
