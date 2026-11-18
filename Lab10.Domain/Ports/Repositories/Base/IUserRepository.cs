using Lab10.Domain.Entities;

namespace Lab10.Domain.Ports.Repositories.Base;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByEmailAsync(string email);
}