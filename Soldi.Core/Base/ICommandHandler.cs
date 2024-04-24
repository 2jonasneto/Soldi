namespace Soldi.Core.Base
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task<(bool Success, string Message)> Handle(T t);
    }
}