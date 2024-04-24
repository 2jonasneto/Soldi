namespace Soldi.Core.Base
{
    public interface IService<T> where T:class
    {
        Task<(bool, string)> Adicionar(T t);
    }
}