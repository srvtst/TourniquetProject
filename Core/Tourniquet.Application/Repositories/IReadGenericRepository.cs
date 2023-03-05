using System.Linq.Expressions;
using Tourniquet.Domain.Common;

namespace Tourniquet.Application.Repositories
{
    public interface IReadGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, int page=0, int pageSize=10);
        T Get(Expression<Func<T, bool>> filter);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter);
    }
}