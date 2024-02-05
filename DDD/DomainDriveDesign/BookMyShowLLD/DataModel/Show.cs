namespace BookMyShowLLD.DataModel
{
    public class Show
    {
        public int Id { get; set; }
        public List<Movie> movies;
        public string ShowTime { set; get; }
        public ShowSeatType SeatType { set; get; }
        public int SeatCount { set; get; }
        public List<Seat> seats { get; set; }

    }
}
