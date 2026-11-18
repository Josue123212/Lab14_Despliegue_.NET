using Lab10.Domain.Entities;

namespace Lab10.Domain.Ports.Repositories.Base;

public interface ITicketRepository : IRepository<Ticket>
{
    Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(Guid userId);
}