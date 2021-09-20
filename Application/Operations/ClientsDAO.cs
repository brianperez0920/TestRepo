using Application.Common.Interfaces;
using Dapper;
using Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations
{
    public class ClientsDAO : IClientsDAO
    {
        private readonly IConfiguration configuration;

        public ClientsDAO(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        private DbConnection GetOpenConnection()
        {

            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            return connection;
        }

        public async Task<IEnumerable<Clients>> GetTotalClientsResult()
        {
            
            using (var connection = GetOpenConnection())
            {
                try
                {
                    var sql = "SELECT * FROM [TestDB].[dbo].[Clients]";
                    var results = await connection.QueryAsync<Clients>(sql);
                    return results;
                }
                catch(Exception ex)
                {
                    var error = ex.Message;
                    throw ex;
                }
            }
        }

        public async Task<int> GetDistinctClientsWithApplication()
        {
            using (var connection = GetOpenConnection())
            {
                try
                {
                    var sql = "SELECT COUNT(DISTINCT clientid) FROM [TestDB].[dbo].[Applications]";
                    var results = await connection.QueryAsync<int>(sql);
                    return results.FirstOrDefault();
                }catch(Exception ex)
                {
                    var error = ex.Message;
                    throw ex;
                }
            }
        }

    }
}
