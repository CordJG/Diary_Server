using Diary_Server.Interface;
using Microsoft.EntityFrameworkCore;

namespace Diary_Server.Contexts.Hanlders
{
    public class BaseContextHandler<T> : IBaseContextHandler<T> where T : class 
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly DbContext _context;

        public BaseContextHandler(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
