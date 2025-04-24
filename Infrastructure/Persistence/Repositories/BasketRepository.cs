using System.ComponentModel.DataAnnotations;

namespace Persistence.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connectionMultiplexer)
        : IBasketRepository
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();
        public async Task<bool> DeleteAsync(string id)
            => await _database.KeyDeleteAsync(id);

        public async Task<CustomerBasket?> GetAsync(string id)
        {
            // Get Object From DB
            // Deserialization
            // Return
            var basket = await _database.StringGetAsync(id);
            if (basket.IsNullOrEmpty)
                return null;
            return JsonSerializer.Deserialize<CustomerBasket>(basket!);
           
        }
        // Used For Create & Update
        public async Task<CustomerBasket?> UpdateAsync(CustomerBasket basket, TimeSpan? timeToLive = null)
        {
            var jsonBasket = JsonSerializer.Serialize(basket);
           var isCreatedOrUpdated = await _database.StringSetAsync(basket.Id,jsonBasket ,timeToLive ?? TimeSpan.FromDays(30));

            return isCreatedOrUpdated ? await GetAsync(basket.Id) : null;
        }
    }
}
