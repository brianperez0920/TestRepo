using Application.Common.Interfaces;
using Dapper;
using Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Application.Operations
{
    public class CreditDAO : ICreditDAO
    {
        private readonly IConfiguration configuration;

        public CreditDAO(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        private DbConnection GetOpenConnection()
        {

            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            return connection;
        }
        public async Task<IEnumerable<Credits>> GetTotalClientsResult()
        {

            using (var connection = GetOpenConnection())
            {
                try
                {
                    var sql = "SELECT * FROM [TestDB].[dbo].[Credit]";
                    var results = await connection.QueryAsync<Credits>(sql);
                    return results;
                }
                catch (Exception ex)
                {
                    var error = ex.Message;
                    throw ex;
                }
            }
        }
    }
}
