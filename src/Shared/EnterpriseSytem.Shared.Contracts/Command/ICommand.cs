using MediatR;

namespace EnterpriseSytem.Shared.Contracts.Command
{
    public interface ICommand : ICommand<Unit>
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }

}
