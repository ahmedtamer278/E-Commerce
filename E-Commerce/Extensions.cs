using Domain.Contracts;
using E_Commerce.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce
{
    public static class Extensions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddWebApplicationServices(this IServiceCollection services) 
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = APIResponseFactory.GenerateAPIValidationResponse;
            });
            services.AddSwaggerServices();
            return services;
        }

        public static async Task <WebApplication> InitializeDataBaseAsync(this WebApplication app) 
        {
              
            using var scope = app.Services.CreateScope();
            var dbinitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbinitializer.InitializeAsync();
            return app;
        }
    }
}
