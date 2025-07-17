using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechChallenge.GameStore.Domain.Repositories;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GameStoreContext _context;

        public Repository(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> Get(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(expression)
                .FirstOrDefaultAsync();
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
