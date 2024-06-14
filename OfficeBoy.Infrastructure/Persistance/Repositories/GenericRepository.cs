using Microsoft.EntityFrameworkCore;
using OfficeBoy.Domain.Interfaces;
using OfficeBoy.Infrastructure.Persistance.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficeBoy.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OfficeBoyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(OfficeBoyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
