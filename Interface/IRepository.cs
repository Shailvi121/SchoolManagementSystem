using System.Linq.Expressions;

namespace SchoolManagementSystem.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
