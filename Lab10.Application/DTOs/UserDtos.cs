namespace Lab10.Application.DTOs;

public record UserResponseDto(
    Guid UserId,
    string Username,
    string? Email,
    DateTime? CreatedAt
);

public record CreateUserRequestDto(
    string Username,
    string PasswordHash,
    string? Email
);