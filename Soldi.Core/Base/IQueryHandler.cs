using System.Linq.Expressions;

namespace Soldi.Core.Base
{
    public interface IQueryHandler<T,Y> where T : IDTO where Y : Entity
    {
        
        Task<(bool Success, string Message,IEnumerable<T>? t)> GetAll();
        Task<(bool Success, string Message,T t)> GetById(Guid id);
        Task<(bool Success, string Message,IEnumerable<T>? t)> GetByExpression(Expression<Func<Y,bool>> expression);
    }

   
}