using Ticketing.Domain.Entities;

namespace Ticketing.Application.Interfaces;

public interface ITicketService
{
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket?> GetTicketByIdAsync(Guid id);
    Task<Ticket> CreateTicketAsync(Ticket ticket);

    Task AddCommentAsync(Guid ticketId, Comment comment);
}
