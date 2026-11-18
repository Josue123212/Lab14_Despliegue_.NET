namespace Lab10.Domain.Ports.Repositories.Base;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    ITicketRepository Tickets { get; }
    IResponseRepository Responses { get; }
    IRoleRepository Roles { get; }
    
    Task<int> SaveChangesAsync();
}