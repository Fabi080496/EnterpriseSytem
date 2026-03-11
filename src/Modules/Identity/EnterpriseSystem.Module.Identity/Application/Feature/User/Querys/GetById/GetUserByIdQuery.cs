using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.Users.Querys.GetBy
{
    public record GetUserByIdQuery(Guid UserId)
        : IRequest<UserDto?>;
}
