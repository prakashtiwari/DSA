namespace BookmyShowLLDDesign.Model
{
    public class Show
    {
        public Auditorium Auditorium { get; set; }
        public Movie Movie { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<ShowFeature> ShowFeature { get; set; }
        public List<ShowSeat> ShowSeats { get; set; }
        public Language Language { get; set; }
        public ShowSeatType SeatType { get; set; }
    }
}
