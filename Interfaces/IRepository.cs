using BlazorAppExcel.Models;

namespace BlazorAppExcel.API.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> GetById(string id);
        Task<IList<T>> ListAsync();
        Task DeleteAsync(T entity);
        public Task InsertAsync(T entity);
        public Task Update(T entity);
        public Task Add(T entity);
        public void Edit(T entity);
    }

}
