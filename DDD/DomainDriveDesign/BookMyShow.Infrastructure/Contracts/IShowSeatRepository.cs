using BookmyShowLLDDesign.Model;

namespace BookMyShow.Infrastructure.Contracts
{
    public interface IShowSeatRepository
    {
        List<ShowSeat> GetShowSeats(IList<int> showSeatIds);
    }
}
