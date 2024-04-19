using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Base
{
    public interface IRepository<T>where T : Entity
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> CreateRangeAsync(List<T> entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRangeAsync(List<T> entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteRangeAsync(List<T> entity);
        Task<T> GetByIdAsync(Guid id);
        IEnumerable<Task<T>> GetAllAsync();
        IEnumerable<Task<T>> GetEnumerableByQueryAsync(Expression<Func<T,bool>> expression);
        IQueryable<Task<T>> GetQueriableByQueryAsync(Expression<Func<T,bool>> expression);

    }
}
