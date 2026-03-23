using MediatR;

namespace EnterpriseSystem.Module.Organization.Application.Users.Querys.GetBy
{
    public record GetUserByIdQuery(Guid UserId)
        : IRequest<UserDto?>;
}
