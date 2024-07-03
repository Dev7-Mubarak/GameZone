using GameZone.Data;
using GameZone.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameZone.Repository
{
    public class MainPepository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public MainPepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return  await _context.Set<T>().ToListAsync();
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }

        public IEnumerable<T> GetAll(string[] agers)
        {
            IQueryable<T> query = _context.Set<T>();

            if(agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return query.ToList();
        }
    }
}
