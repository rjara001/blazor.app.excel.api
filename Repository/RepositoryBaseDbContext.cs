using BlazorAppExcel.API.Interfaces;
using BlazorAppExcel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppExcel.API.Repository;
{
    public class RepositoryBaseDbContext<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext _dbContext;

        public RepositoryBaseDbContext(DbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public virtual async Task<T> GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> ListAsync()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                   .Where(predicate)
                   .AsEnumerable();
        }

        public async Task InsertAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Add(T entity)
        {
            await InsertAsync(entity);
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        Task<IList<T>> IRepository<T>.ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
