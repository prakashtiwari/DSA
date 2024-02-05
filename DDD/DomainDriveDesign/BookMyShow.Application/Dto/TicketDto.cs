using BookMyShow.Application.Dto;

namespace BookMyShow.Domain.Dto
{
    public class TicketDto
    {
        public int Id { get; set; }
        public DateTime BookingTime { get; set; }

        public ShowDto showDto { get; set; }
    }
}
