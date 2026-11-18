using Lab10.Application.DTOs;
using Lab10.Domain.Entities;
using Lab10.Domain.Ports.Repositories.Base;

namespace Lab10.Application.UseCases.UserUseCase;

public class AddUserUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public AddUserUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserResponseDto> ExecuteAsync(CreateUserRequestDto request)
    {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = request.Username,
            PasswordHash = request.PasswordHash,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return new UserResponseDto(
            user.UserId,
            user.Username,
            user.Email,
            user.CreatedAt
        );
    }
}