namespace BookmyShowLLDDesign.Model
{
    public class Ticket
    {
        public User User { get; set; }
        public Show Show { get; set; }
        public List<ShowSeat> ShowSeats { get; set; }

        public DateTime BookedTime { get; set; }
        public double TotalAmount { get; set; }

        public TicketStatus Status { get; set; }
    }
}
