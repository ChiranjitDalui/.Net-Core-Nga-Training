// here in this class we are implementing the Unit of Work pattern with the help of
// a generic repository
// This class will coordinate the work of multiple repositories
// It will ensure that all changes are saved to the database in a single transaction
// This helps to maintain data integrity and consistency

using System.Linq.Expressions; // for specifying query filters
using Microsoft.EntityFrameworkCore; // for accessing the DbContext and DbSet
using RepoDemo.Api.Data; // for accessing the application DbContext
using RepoDemo.Api.Repository.Interfaces; // for accessing the IGenericRepository interface
using RepoDemo.Api.Models; // for accessing the Product and Category models

namespace RepoDemo.Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IGenericRepository<Product> _productRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _productRepository = new GenericRepository<Product>(_context);
        }

        // Implement the Products property as required by IUnitOfWork
        public IGenericRepository<Product> Products => _productRepository;

        // Update SaveChangesAsync to return Task<int> as required by IUnitOfWork
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Implement IDisposable
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}