namespace Persistence
{
    public class DbInitializer (StoreDbContext context) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            ///if ((await context.Database.GetPendingMigrationsAsync()).Any())
            /// await context.Database.MigrateAsync();

            try
            {
                if (context.Set<ProductType>().Any())
                {
                    // Read From File
                    var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\brands.json");
                    // Convert to c# object [Deserilaize]
                    var objects = JsonSerializer.Deserialize<List<ProductBrand>>(data);
                    //Save to Db
                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductBrand>().AddRange(objects);
                        await context.SaveChangesAsync();
                    }
                }

                if (context.Set<ProductType>().Any())
                {
                    // Read From File
                    var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\types.json");
                    // Convert to c# object [Deserilaize]
                    var objects = JsonSerializer.Deserialize<List<ProductType>>(data);
                    //Save to Db
                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductType>().AddRange(objects);
                        await context.SaveChangesAsync();
                    }
                }

                if (context.Set<Product>().Any())
                {
                    // Read From File
                    var data = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\products.json");
                    // Convert to c# object [Deserilaize]
                    var objects = JsonSerializer.Deserialize<List<Product>>(data);
                    //Save to Db
                    if (objects is not null && objects.Any())
                    {
                        context.Set<Product>().AddRange(objects);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
