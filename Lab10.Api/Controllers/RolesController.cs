using Lab10.Application.DTOs;
using Lab10.Application.UseCases.RoleUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly AddRoleUseCase _addRoleUseCase;
    private readonly GetAllRolesUseCase _getAllRolesUseCase;

    public RolesController(
        AddRoleUseCase addRoleUseCase,
        GetAllRolesUseCase getAllRolesUseCase)
    {
        _addRoleUseCase = addRoleUseCase;
        _getAllRolesUseCase = getAllRolesUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllRolesUseCase.ExecuteAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleRequestDto request)
    {
        var result = await _addRoleUseCase.ExecuteAsync(request);
        return Ok(result);
    }
}