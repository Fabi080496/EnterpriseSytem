using EnterpriseSystem.Module.Identity.Domain.Interfaces;
using MediatR;
namespace EnterpriseSystem.Module.Identity.Application.User.Querys.GetBy
{
    public class GetUserByIdQueryHandler
        : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto?> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);

            return user == null
                ? null
                : new UserDto(user.Id, user.Email);
        }
    }
}
