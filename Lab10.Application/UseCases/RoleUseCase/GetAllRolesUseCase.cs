using Lab10.Application.DTOs;
using Lab10.Domain.Ports.Repositories.Base;

namespace Lab10.Application.UseCases.RoleUseCase;

public class GetAllRolesUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRolesUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RoleResponseDto>> ExecuteAsync()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();

        return roles.Select(r => new RoleResponseDto(
            r.RoleId,
            r.RoleName
        ));
    }
}