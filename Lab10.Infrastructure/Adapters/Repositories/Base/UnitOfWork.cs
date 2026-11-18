using Lab10.Domain.Ports.Repositories.Base;
using Lab10.Infrastructure.Context;

namespace Lab10.Infrastructure.Adapters.Repositories.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IUserRepository Users { get; }
    public ITicketRepository Tickets { get; }
    public IResponseRepository Responses { get; }
    public IRoleRepository Roles { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
        Tickets = new TicketRepository(_context);
        Responses = new ResponseRepository(_context);
        Roles = new RoleRepository(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}