using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repositories.Base;
using Lab10.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Adapters.Repositories.Base;

public class ResponseRepository : Repository<Response>, IResponseRepository
{
    public ResponseRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Response>> GetResponsesByTicketIdAsync(Guid ticketId)
    {
        return await _context.Responses
            .Where(r => r.TicketId == ticketId)
            .OrderBy(r => r.CreatedAt)
            .ToListAsync();
    }
}