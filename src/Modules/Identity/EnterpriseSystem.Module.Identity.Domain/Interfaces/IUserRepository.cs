using EnterpriseSystem.Module.Identity.Domain.Domain;

namespace EnterpriseSystem.Module.Identity.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
    }
}
