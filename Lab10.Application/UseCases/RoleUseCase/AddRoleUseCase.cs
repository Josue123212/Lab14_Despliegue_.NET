using Lab10.Application.DTOs;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repositories.Base;

namespace Lab10.Application.UseCases.RoleUseCase;

public class AddRoleUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public AddRoleUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RoleResponseDto> ExecuteAsync(CreateRoleRequestDto request)
    {
        var role = new Role
        {
            RoleId = Guid.NewGuid(),
            RoleName = request.RoleName
        };

        await _unitOfWork.Roles.AddAsync(role);
        await _unitOfWork.SaveChangesAsync();

        return new RoleResponseDto(
            role.RoleId,
            role.RoleName
        );
    }
}