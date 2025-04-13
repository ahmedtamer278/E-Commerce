namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey>(StoreDbContext context)
        : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public void Add(TEntity entity)
            => context.Set<TEntity>().Add(entity);

        public void Delete(TEntity entity)
            => context.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await context.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetAsync(TKey key)
            => await context.Set<TEntity>().FindAsync(key);

        public void Update(TEntity entity)
            => context.Set<TEntity>().Update(entity);
    }
}
