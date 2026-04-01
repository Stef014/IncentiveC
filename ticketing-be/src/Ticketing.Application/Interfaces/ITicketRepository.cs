using Ticketing.Domain.Entities;

namespace Ticketing.Application.Interfaces;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(Guid id);
    Task<Ticket> CreateAsync(Ticket ticket);
    Task<Ticket> UpdateAsync(Ticket ticket);

    Task AddCommentAsync(Guid ticketId, Comment comment);
}
