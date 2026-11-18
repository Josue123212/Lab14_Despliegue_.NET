using Lab10.Application.DTOs;
using Lab10.Domain.Ports.Repositories.Base;

namespace Lab10.Application.UseCases.TicketUseCase;

public class GetAllTicketsUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTicketsUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TicketResponseDto>> ExecuteAsync()
    {
        var tickets = await _unitOfWork.Tickets.GetAllAsync();

        return tickets.Select(t => new TicketResponseDto(
            t.TicketId,
            t.Title,
            t.Description,
            t.Status,
            t.CreatedAt,
            t.UserId
        ));
    }
}