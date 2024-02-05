using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BookMyShow.Infrastructure.Context
{
    public class DatabaseContext
    {
        private readonly string connectionString;
        private readonly IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlDatabaseConnection");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
