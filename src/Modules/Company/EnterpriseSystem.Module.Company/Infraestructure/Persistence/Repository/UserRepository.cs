using EnterpriseSystem.Module.Organization.Domain.Entities;
using EnterpriseSystem.Module.Organization.Domain.Interfaces;
using EnterpriseSystem.Module.Organization.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace EnterpriseSystem.Module.Organization.Infraestructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CompanyDbContext _context;

        public UserRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetByEmailAsync(
            string email,
            CancellationToken ct)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    u => u.Email == email,
                    ct);
        }


    }
}
