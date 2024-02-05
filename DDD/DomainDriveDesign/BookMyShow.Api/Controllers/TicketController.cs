using BookMyShow.Application.Contracts;
using BookMyShow.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketApplicationService _ticketApplicationService;
        public TicketController(ITicketApplicationService ticketApplicationService)
        {
            _ticketApplicationService = ticketApplicationService;
        }

        [HttpPost]
        public async Task SaveTicket([FromBody] TicketDto ticket)
        {
           await _ticketApplicationService.BookTicket(ticket);
            //return Ok(new object());
        }
    }
}
