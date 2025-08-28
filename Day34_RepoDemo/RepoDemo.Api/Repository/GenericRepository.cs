//This file will contain the implementation of the generic repository interface
//It will provide the actual data access logic for the CRUD operations defined in the interface
//It acts as a bridge between the application and the data source, allowing for a more modular and testable codebase.

using System.Linq.Expressions; // for specifying query filters
using Microsoft.EntityFrameworkCore; // for accessing the DbContext and DbSet
using RepoDemo.Api.Data; // for accessing the application DbContext
using RepoDemo.Api.Repository.Interfaces; // for accessing the IGenericRepository interface

namespace RepoDemo.Api.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

        // this class implements the IGenericRepository interface
        // it provides the actual data access logic for the CRUD operations defined in the interface
        // it acts as a bridge between the application and the data source, allowing for a more modular and testable codebase

    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}