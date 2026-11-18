namespace Lab10.Application.DTOs;

public record RoleResponseDto(
    Guid RoleId,
    string RoleName
);

public record CreateRoleRequestDto(
    string RoleName
);