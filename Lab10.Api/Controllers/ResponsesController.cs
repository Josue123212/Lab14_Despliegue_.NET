using Lab10.Application.DTOs;
using Lab10.Application.UseCases.ResponseUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsesController : ControllerBase
{
    private readonly AddResponseUseCase _addResponseUseCase;
    private readonly GetResponsesByTicketIdUseCase _getResponsesByTicketIdUseCase;

    public ResponsesController(
        AddResponseUseCase addResponseUseCase,
        GetResponsesByTicketIdUseCase getResponsesByTicketIdUseCase)
    {
        _addResponseUseCase = addResponseUseCase;
        _getResponsesByTicketIdUseCase = getResponsesByTicketIdUseCase;
    }

    [HttpGet("ticket/{ticketId:guid}")]
    public async Task<IActionResult> GetByTicketId(Guid ticketId)
    {
        var result = await _getResponsesByTicketIdUseCase.ExecuteAsync(ticketId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateResponseRequestDto request)
    {
        var result = await _addResponseUseCase.ExecuteAsync(request);
        return Ok(result);
    }
}