using Lab10.Domain.Entities;

namespace Lab10.Domain.Ports.Repositories.Base;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetByNameAsync(string roleName);
}