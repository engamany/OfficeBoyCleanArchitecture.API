using OfficeBoy.Models;

namespace OfficeBoy.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Order> Orders { get; }
        // Add other repositories as properties here
        Task<int> CommitAsync();
    }
}
