using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tourniquet.Application.Repositories;
using Tourniquet.Domain.Common;

namespace Tourniquet.Persistence.Repositories
{
    public class ReadGenericRepository<T, TContext> : IReadGenericRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        protected TContext Context { get; set; }
        public ReadGenericRepository(TContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, int page = 0, int pageSize = 100)
        {
            return Context.Set<T>().AsNoTracking().AsQueryable().Skip(page).Take(pageSize);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().AsNoTracking().SingleOrDefault(filter);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().Where(filter).AsNoTracking();
        }
    }
}