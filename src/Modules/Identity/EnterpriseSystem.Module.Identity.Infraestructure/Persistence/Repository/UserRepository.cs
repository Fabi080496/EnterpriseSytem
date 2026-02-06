using EnterpriseSystem.Module.Identity.Domain.Domain;
using EnterpriseSystem.Module.Identity.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace EnterpriseSystem.Module.Identity.Infraestructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _context;

        public UserRepository(IdentityDbContext context)
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
    }
}
