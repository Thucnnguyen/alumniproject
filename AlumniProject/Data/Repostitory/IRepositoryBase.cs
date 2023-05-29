using AlumniProject.Dto;
using System.Linq.Expressions;

namespace AlumniProject.Data.Repostitory
{
    public interface IRepositoryBase<T>
    {
        Task<PagingResultDTO<T>> GetAllByConditionAsync(int pageNo, int pageSize, Expression<Func<T, bool>> filter);
        Task<int> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<T> FindOneByCondition( Expression<Func<T, bool>> filter);
    }
}
