using Lab10.Application.DTOs;
using Lab10.Application.UseCases.TicketUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly AddTicketUseCase _addTicketUseCase;
    private readonly GetAllTicketsUseCase _getAllTicketsUseCase;
    private readonly GetTicketByIdUseCase _getTicketByIdUseCase;

    public TicketsController(
        AddTicketUseCase addTicketUseCase,
        GetAllTicketsUseCase getAllTicketsUseCase,
        GetTicketByIdUseCase getTicketByIdUseCase)
    {
        _addTicketUseCase = addTicketUseCase;
        _getAllTicketsUseCase = getAllTicketsUseCase;
        _getTicketByIdUseCase = getTicketByIdUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllTicketsUseCase.ExecuteAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getTicketByIdUseCase.ExecuteAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketRequestDto request)
    {
        var result = await _addTicketUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.TicketId }, result);
    }
}