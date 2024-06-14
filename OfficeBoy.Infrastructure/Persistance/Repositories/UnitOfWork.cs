using OfficeBoy.Domain.Interfaces;
using OfficeBoy.Infrastructure.Persistance.Contexts;
using OfficeBoy.Models;
using System;
using System.Threading.Tasks;

namespace OfficeBoy.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OfficeBoyDbContext _context;
        
        

        public UnitOfWork(OfficeBoyDbContext context)
        {
            _context = context;
            Orders = new GenericRepository<Order>(context);
            
        }

        public IGenericRepository<Order> Orders { get; }
        

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
