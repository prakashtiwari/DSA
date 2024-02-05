using BookMyShow.Application.Contracts;
using BookMyShow.Domain.Dto;
using BookMyShow.Infrastructure.Contracts;
using BookmyShowLLDDesign.Model;

namespace BookMyShow.Application.Services
{
    public class TicketApplicationService : ITicketApplicationService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketApplicationService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task BookTicket(TicketDto ticketDto)
        {
           await _ticketRepository.BookTicket(new Ticket());
        }
    }
}
