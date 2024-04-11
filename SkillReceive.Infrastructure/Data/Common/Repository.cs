
using Microsoft.EntityFrameworkCore;

namespace SkillReceive.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(SkillReceiveDbContext _context)
        {
            context = _context; 
        }

        private DbSet<T> DbSet<T>() where T : class 
        {
            return context.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnlyOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }
    }
}
