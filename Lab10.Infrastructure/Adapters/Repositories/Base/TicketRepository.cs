using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repositories.Base;
using Lab10.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab10.Infrastructure.Adapters.Repositories.Base;

public class TicketRepository : Repository<Ticket>, ITicketRepository
{
    public TicketRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(Guid userId)
    {
        return await _context.Tickets
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }
}