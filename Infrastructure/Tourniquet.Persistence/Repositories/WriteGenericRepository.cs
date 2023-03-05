using Microsoft.EntityFrameworkCore;
using Tourniquet.Application.Repositories;
using Tourniquet.Domain.Common;

namespace Tourniquet.Persistence.Repositories
{
    public class WriteGenericRepository<T, TContext> : IWriteGenericRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        protected TContext Context { get; }
        public WriteGenericRepository(TContext context)
        {
            Context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<T>> AddRangeAsync(IList<T> entity)
        {
            foreach (var item in entity)
            {
                Context.Entry(item).State = EntityState.Added;
            }
            await Context.SaveChangesAsync();
            return entity.ToList();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<T>> UpdateRangeAsync(IList<T> entity)
        {
            foreach (var item in entity)
            {
                Context.Entry(item).State = EntityState.Modified;
            }
            await Context.SaveChangesAsync();
            return entity.ToList();
        }

        public async Task<T> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<T>> DeleteRangeAsync(IList<T> entity)
        {
            foreach (var item in entity)
            {
                Context.Entry(item).State = EntityState.Deleted;
            }
            await Context.SaveChangesAsync();
            return entity.ToList();
        }
    }
}