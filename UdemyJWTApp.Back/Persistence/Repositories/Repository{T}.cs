using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Persistence.Context;

namespace UdemyJWTApp.Back.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly UdemyJwtContext _udemyJwtContext;

        public Repository(UdemyJwtContext udemyJwtContext)
        {
            _udemyJwtContext = udemyJwtContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _udemyJwtContext.Set<T>().AddAsync(entity);
            await _udemyJwtContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _udemyJwtContext.Set<T>().AsNoTracking().ToListAsync();        
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _udemyJwtContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _udemyJwtContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _udemyJwtContext.Set<T>().Remove(entity);
            await _udemyJwtContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _udemyJwtContext.Set<T>().Update(entity);
            await _udemyJwtContext.SaveChangesAsync();
        }
    }
}
