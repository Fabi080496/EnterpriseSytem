using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.Querys.GetByUser
{
    public record GetUserByIdQuery(Guid UserId)
        : IRequest<UserDto?>;
}
