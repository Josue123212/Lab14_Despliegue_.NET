using Lab10.Domain.Entities;

namespace Lab10.Domain.Ports.Repositories.Base;

public interface IResponseRepository : IRepository<Response>
{
    Task<IEnumerable<Response>> GetResponsesByTicketIdAsync(Guid ticketId);
}