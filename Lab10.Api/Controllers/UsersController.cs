using Lab10.Application.DTOs;
using Lab10.Application.UseCases.UserUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AddUserUseCase _addUserUseCase;
    private readonly GetAllUsersUseCase _getAllUsersUseCase;

    public UsersController(
        AddUserUseCase addUserUseCase,
        GetAllUsersUseCase getAllUsersUseCase)
    {
        _addUserUseCase = addUserUseCase;
        _getAllUsersUseCase = getAllUsersUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllUsersUseCase.ExecuteAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequestDto request)
    {
        var result = await _addUserUseCase.ExecuteAsync(request);
        return Ok(result);
    }
}