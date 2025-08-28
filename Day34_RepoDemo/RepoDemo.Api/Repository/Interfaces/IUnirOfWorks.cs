//IUnitofWork is used here to group related operations into a single transaction
//ex: saving changes to multiple entities in a single database transaction
//ex: committing all changes or rolling back in case of an error
// So, UnitOfWork is responsible for coordinating the work of multiple repositories by providing a single
// interface for saving changes.
using System.Linq.Expressions;
using RepoDemo.Api.Models;// this will help us in accessing the wetherForcast Model / any model

namespace RepoDemo.Api.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable // this interface is used to manage the lifetime of the unit of work
    {
        IGenericRepository<Product> Products { get; } // here Products is a repository for Product entities and we can define other repositories in a similar manner
        Task<int> SaveChangesAsync();// this method is used to save all changes made in the unit of work / data base
    }
}