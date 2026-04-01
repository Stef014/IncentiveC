using Ticketing.Application.Interfaces;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
        return await _ticketRepository.GetAllAsync();
    }

    public async Task<Ticket?> GetTicketByIdAsync(Guid id)
    {
        return await _ticketRepository.GetByIdAsync(id);
    }

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        ticket.Id = Guid.NewGuid();
        ticket.Status = Domain.Enums.TicketStatus.Open;
        ticket.CreatedAt = DateTime.UtcNow;
        return await _ticketRepository.CreateAsync(ticket);
    }

    public async Task AddCommentAsync(Guid ticketId, Comment comment)
    {
        var ticket = await _ticketRepository.GetByIdAsync(ticketId);
        
        if (ticket is null)
        {
            throw new Exception("Ticket not found");
        }
        
        comment.Id = Guid.NewGuid();
        comment.TicketId = ticketId;
        comment.CreatedAt = DateTime.UtcNow;
        
        await _ticketRepository.AddCommentAsync(ticketId, comment);
    }
}
