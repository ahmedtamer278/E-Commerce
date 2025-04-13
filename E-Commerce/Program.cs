
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace E_Commerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(ConnectionString);
            });
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
          await  InitializerDbAsync(app);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        public static async Task InitializerDbAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbinitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbinitializer.InitializeAsync();
        }
    }

}
