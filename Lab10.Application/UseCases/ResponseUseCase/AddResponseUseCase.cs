using Lab10.Application.DTOs;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repositories.Base;

namespace Lab10.Application.UseCases.ResponseUseCase;

public class AddResponseUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public AddResponseUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseTicketDto> ExecuteAsync(CreateResponseRequestDto request)
    {
        var response = new Response
        {
            ResponseId = Guid.NewGuid(),
            TicketId = request.TicketId,
            ResponderId = request.ResponderId,
            Message = request.Message,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Responses.AddAsync(response);
        await _unitOfWork.SaveChangesAsync();

        return new ResponseTicketDto(
            response.ResponseId,
            response.TicketId,
            response.ResponderId,
            response.Message,
            response.CreatedAt
        );
    }
}