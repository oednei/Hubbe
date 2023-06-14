using Hubbe.Services.Restaurant.Data.Context;
using Hubbe.Services.Restaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hubbe.Services.Restaurant.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _dbContext;

        public BaseRepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Delete(int ID)
        {
            var entity = await FindById(ID);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FindById(int ID)
        {
            return await _dbContext.Set<T>().FindAsync(ID);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int ID, T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Find(T entity)
        {
            return await _dbContext.Set<T>().FindAsync(entity);
        }

    }
}
