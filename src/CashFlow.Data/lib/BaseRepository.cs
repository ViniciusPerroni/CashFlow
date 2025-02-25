using CashFlow.Crosscutting;
using CashFlow.Domain.lib;

using Microsoft.EntityFrameworkCore;

namespace CashFlow.Data.lib
{
    public abstract class BaseRepository<T> : ICrudRepository<T> where T : BaseEntity
    {
        protected readonly CashFlowDbContext _cashFlowDbContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(CashFlowDbContext cashFlowDbContext)
        {
            _cashFlowDbContext = cashFlowDbContext;
            _dbSet = _cashFlowDbContext.Set<T>();
        }

        public virtual async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _cashFlowDbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(long id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _cashFlowDbContext.SaveChangesAsync();
            }
        }

        public virtual async Task<PagedResult<T>> GetAll(int page, int pageSize)
        {
            var query = _dbSet;
            var pagedResult = new PagedResult<T>();
            var skip = (page - 1) * pageSize;
            pagedResult.RowCount = query.Count();

            pagedResult.Rows = await query.Skip(skip).Take(pageSize).ToListAsync();

            return pagedResult;
        }

        public virtual async Task<T> GetById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _cashFlowDbContext.SaveChangesAsync();
        }
    }
}
