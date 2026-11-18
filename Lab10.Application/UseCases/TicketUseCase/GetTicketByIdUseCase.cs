using Lab10.Application.DTOs;
using Lab10.Domain.Ports.Repositories.Base;

namespace Lab10.Application.UseCases.TicketUseCase;

public class GetTicketByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTicketByIdUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TicketResponseDto?> ExecuteAsync(Guid id)
    {
        var ticket = await _unitOfWork.Tickets.GetByIdAsync(id);
        if (ticket == null) return null;

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