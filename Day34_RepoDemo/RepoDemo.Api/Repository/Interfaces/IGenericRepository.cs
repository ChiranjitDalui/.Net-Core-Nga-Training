using System.Linq.Expressions;

namespace RepoDemo.Api.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // we are calling this class as IGenericRepository as it is a generic interface for all the repositories
        Task<IEnumerable<T>> GetAllAsync();
        // this method will help us in retrieving all records
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);// task type help us in performing async operations
        // this method will help us in adding new records in async manner
        Task UpdateAsync(T entity);
        // this method will help us in the updating existing entity in async manner

        Task DeleteAsync(int id);
        // this method will help us in deleting existing records in async manner
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
// all the methods that are defined in this interface will help us in performing CRUD operations on the entities