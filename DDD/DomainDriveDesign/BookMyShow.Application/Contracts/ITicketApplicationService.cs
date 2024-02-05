using BookMyShow.Domain.Dto;

namespace BookMyShow.Application.Contracts
{
    public interface ITicketApplicationService
    {
        Task BookTicket(TicketDto ticketDto);
    }
}
