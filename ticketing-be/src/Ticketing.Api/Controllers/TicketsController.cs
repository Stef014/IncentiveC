using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Interfaces;
using Ticketing.Domain.Entities;

namespace Ticketing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetAll()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        return Ok(tickets);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Ticket>> GetById(Guid id)
    {
        try
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket is null)
                return NotFound();

            return Ok(ticket);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Ticket>> Create(Ticket ticket)
    {
        try {
            var created = await _ticketService.CreateTicketAsync(ticket);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id:guid}/comments")]
    public async Task<ActionResult<Comment>> AddComment([FromRoute] Guid id, [FromBody] string message)
    {
        try {
            var comment = new Comment { Message = message };
            await _ticketService.AddCommentAsync(id, comment);
            if (comment is null)
                return NotFound();

            return CreatedAtAction(nameof(GetById), new { id }, comment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
