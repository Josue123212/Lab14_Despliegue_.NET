using Lab10.Application.DTOs;
using Lab10.Domain.Ports.Repositories.Base;

namespace Lab10.Application.UseCases.ResponseUseCase;

public class GetResponsesByTicketIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetResponsesByTicketIdUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ResponseTicketDto>> ExecuteAsync(Guid ticketId)
    {
        var responses = await _unitOfWork.Responses.GetResponsesByTicketIdAsync(ticketId);

        return responses.Select(r => new ResponseTicketDto(
            r.ResponseId,
            r.TicketId,
            r.ResponderId,
            r.Message,
            r.CreatedAt
        ));
    }
}