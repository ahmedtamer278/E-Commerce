
namespace Persistence
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration) 
        {
            services.AddDbContext<StoreDbContext>(options =>
            {
                var ConnectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(ConnectionString);
            });
            services.AddDbContext<StoreIdentityDbContext>(options =>
            {
                var ConnectionString = configuration.GetConnectionString("IdentityConnection");
                options.UseSqlServer(ConnectionString);
            });
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddSingleton<IConnectionMultiplexer>((_) =>
            {
               return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")!);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            ConfigureIdentity(services , configuration);
            return services;
        }

        private static void ConfigureIdentity(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<ApplicationUser>(config =>
            {
                config.User.RequireUniqueEmail = true;

                config.Password.RequiredLength = 8;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;   
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;

            })
                 .AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<StoreIdentityDbContext>();
        }
    }
}
