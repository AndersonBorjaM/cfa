using Microsoft.EntityFrameworkCore;

namespace Repository.Base
{
    public abstract class BaseRepository<Entiry> where Entiry : class
    {
        protected readonly DbContext _applicationContext;
        protected DbSet<Entiry> _table;

        protected BaseRepository(DbContext applicationContext)
        {
            _table = applicationContext.Set<Entiry>();
            _applicationContext = applicationContext;
        }

        public async Task<Entiry> CreateAsync(Entiry entity)
        {
            var resp = await _table.AddAsync(entity);
            await _applicationContext.SaveChangesAsync();
            return resp.Entity;
        }

        public async Task<bool> DeleteAsync(Entiry entity)
        {
            _table.Remove(entity);
            await _applicationContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Entiry>> GetAllAsync()
        => _table;

        public async Task<Entiry> UpdateAsync(Entiry entity)
        {
            var resp = _table.Update(entity);
            await _applicationContext.SaveChangesAsync();
            return resp.Entity;
        }
    }
}
