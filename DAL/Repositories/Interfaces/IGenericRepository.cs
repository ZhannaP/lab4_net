using DAL.Base;

namespace DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<int> SaveChangesAsync();
    }
}
