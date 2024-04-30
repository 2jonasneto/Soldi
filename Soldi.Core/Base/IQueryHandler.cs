using System.Linq.Expressions;

namespace Soldi.Core.Base
{
    public interface IQueryHandler<T> where T : IDTO
    {
        
        Task<(bool Success, string Message,IEnumerable<T>? t)> GetAll();
        Task<(bool Success, string Message,T t)> GetById(Guid id);
        Task<(bool Success, string Message,IEnumerable<T>? t)> GetByExpression(Expression<Func<T,bool>> expression);
    }
}