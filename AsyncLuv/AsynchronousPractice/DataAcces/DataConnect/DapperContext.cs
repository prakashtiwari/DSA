using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.DataConnect
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionSTring;
        public DapperContext()
        {
           // _configuration = configuration;
            connectionSTring = "Data Source=.;Initial Catalog=StockDb;Integrated Security=True";
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionSTring);

    }
}
