using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repositories.Base;
using Lab10.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Adapters.Repositories.Base;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Role?> GetByNameAsync(string roleName)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(r => r.RoleName == roleName);
    }
}