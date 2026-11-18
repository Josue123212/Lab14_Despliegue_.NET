using Lab10.Application.DTOs;
using Lab10.Domain.Ports.Repositories.Base;

namespace Lab10.Application.UseCases.UserUseCase;

public class GetAllUsersUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsersUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserResponseDto>> ExecuteAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();

        return users.Select(u => new UserResponseDto(
            u.UserId,
            u.Username,
            u.Email,
            u.CreatedAt
        ));
    }
}