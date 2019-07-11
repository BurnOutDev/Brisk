using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Brisk.Persistence;
using Brisk.Application;

namespace Brisk.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Quote Quiz API",
                    Version = "v1"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });
            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services, IHostingEnvironment env)
        {
            var config = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json")
             .Build();

            services.AddDbContext<BriskDbContext>(x=> x.UseSqlServer(config.GetConnectionString("Connection")));
            return services;
        }

        public static IServiceCollection AddDI(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQuoteService, QuoteService>();
            return services;
        }
    }
}
