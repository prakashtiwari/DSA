using BookMyShow.Infrastructure.Contracts;
using BookmyShowLLDDesign.Model;

namespace BookMyShow.Infrastructure.Repository
{
    public class ShowSeatRepository:IShowSeatRepository
    {
        public ShowSeatRepository() { 
        }
        public List<ShowSeat> GetShowSeats(IList<int> id)
        {
            return new List<ShowSeat>();
        }
    }
}
