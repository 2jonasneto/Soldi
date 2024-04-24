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
       void Create(T entity);
       void CreateRange(List<T> entity);
       void Update(T entity);
       void UpdateRange(List<T> entity);
       void Delete(T entity);
       void DeleteRange(List<T> entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetEnumerableByQueryAsync(Expression<Func<T,bool>> expression);
        Task<IQueryable<T>> GetQueriableByQueryAsync(Expression<Func<T,bool>> expression);

    }
}
