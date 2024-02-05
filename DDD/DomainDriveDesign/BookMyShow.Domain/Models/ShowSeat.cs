namespace BookmyShowLLDDesign.Model
{
    public class ShowSeat
    {
        public Seat Seat { get; set; }
        public Show Show { get; set; }

        public ShowSeatState SeatState { get; set; }
    }
}
