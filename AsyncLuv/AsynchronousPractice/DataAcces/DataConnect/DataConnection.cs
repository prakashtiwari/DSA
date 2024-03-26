using DataAcces.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Diagnostics;

namespace DataAcces.DataConnect
{
    public class DataConnection
    {
        public async Task< List<Stocks>> GetStocks(string stock)
        {
            DapperContext dapperContext = new DapperContext();
            List<Stocks> stockList = new List<Stocks>();
            //string sql = "SELECT *  FROM[StockDb].[dbo].[StockDetails]";
            string sql = "SELECT *  FROM[StockDb].[dbo].[StockDetails] Where Category=@stock";
            try
            {
                using (var con = dapperContext.CreateConnection())
                {

                    //var result =  con.Query<Stocks>(sql);
                    var result = await con.QueryAsync<Stocks>(sql, new { stock });
                    stockList = result.ToList<Stocks>();
                   
                    
                }
            }
            catch (Exception ex) { }

            return stockList;

        }

    }
}
