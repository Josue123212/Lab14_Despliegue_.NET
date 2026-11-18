namespace Lab10.Application.DTOs;

public record ResponseTicketDto(
    Guid ResponseId,
    Guid TicketId,
    Guid ResponderId,
    string Message,
    DateTime? CreatedAt
);

public record CreateResponseRequestDto(
    Guid TicketId,
    Guid ResponderId,
    string Message
);