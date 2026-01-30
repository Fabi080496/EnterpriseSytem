using MediatR;
namespace EnterpriseSytem.Shared.Contracts.Query
{
    public interface IQuery<out T> : IRequest<T>
        where T : notnull
    {
    }
}
