using Lab10.Application.DTOs;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repositories.Base;

namespace Lab10.Application.UseCases.TicketUseCase;

public class AddTicketUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public AddTicketUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TicketResponseDto> ExecuteAsync(CreateTicketRequestDto request)
    {
        var ticket = new Ticket
        {
            TicketId = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description,
            Status = "Open",
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Tickets.AddAsync(ticket);
        await _unitOfWork.SaveChangesAsync();

        return new TicketResponseDto(
            ticket.TicketId,
            ticket.Title,
            ticket.Description,
            ticket.Status,
            ticket.CreatedAt,
            ticket.UserId
        );
    }
}