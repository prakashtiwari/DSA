using BookMyShow.Infrastructure.Context;
using BookMyShow.Infrastructure.Contracts;
using BookmyShowLLDDesign.Model;
using Dapper;

namespace BookMyShow.Infrastructure.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TicketRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task BookTicket(Ticket ticketDto)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                try
                {
                    connection.Open();
                    await connection.ExecuteAsync("", "");
                }
                catch (Exception ex)
                {

                }
               
            }
        }
    }
}
