using Tourniquet.Domain.Common;

namespace Tourniquet.Application.Repositories
{
    public interface IWriteGenericRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<IList<T>> AddRangeAsync(IList<T> entity);
        Task<T> UpdateAsync(T entity);
        Task<IList<T>> UpdateRangeAsync(IList<T> entity);
        Task<T> DeleteAsync(T entity);
        Task<IList<T>> DeleteRangeAsync(IList<T> entity);
    }
}