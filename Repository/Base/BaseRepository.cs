using Microsoft.EntityFrameworkCore;

namespace Repository.Base
{
    public abstract class BaseRepository<Entity> where Entity : class
    {
        protected readonly DbContext _applicationContext;
        protected DbSet<Entity> _table;

        protected BaseRepository(DbContext applicationContext)
        {
            _table = applicationContext.Set<Entity>();
            _applicationContext = applicationContext;
        }

        public async Task<Entity> CreateAsync(Entity entity)
        {
            var resp = await _table.AddAsync(entity);
            await _applicationContext.SaveChangesAsync();
            return resp.Entity;
        }

        public async Task<bool> DeleteAsync(Entity entity)
        {
            _table.Remove(entity);
            await _applicationContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Entity>> GetAllAsync()
        => _table;

        public async Task<Entity> UpdateAsync(Entity entity)
        {
            var resp = _table.Update(entity);
            await _applicationContext.SaveChangesAsync();
            return resp.Entity;
        }
    }
}
