using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.User.Querys.GetBy
{
    public record GetUserByIdQuery(Guid UserId)
        : IRequest<UserDto?>;
}
