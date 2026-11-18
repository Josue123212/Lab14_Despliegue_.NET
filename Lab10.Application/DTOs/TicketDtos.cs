namespace Lab10.Application.DTOs;

public record TicketResponseDto(
    Guid TicketId, 
    string Title, 
    string Description, 
    string Status, 
    DateTime? CreatedAt, // <-- Cambiado a DateTime?
    Guid UserId
);

public record CreateTicketRequestDto(
    Guid UserId, 
    string Title, 
    string Description
);