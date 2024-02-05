using BookmyShowLLDDesign.Model;

namespace BookMyShow.Infrastructure.Contracts
{
    public interface ITicketRepository
    {
        Task BookTicket(Ticket ticketDto);
    }
}
