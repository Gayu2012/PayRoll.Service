using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace PayRoll.Service.DBContext
{
    public class DBContext : IDBContext
    {
        private readonly IConfiguration _configuration;
        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        private DbConnection GetDbConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
        }
        public async Task<int> ExecuteAsync(string sp, DynamicParameters parm = null, CommandType commandType = CommandType.StoredProcedure)
        {
            int Result;
            using (IDbConnection connection = GetDbConnection())
            {
                connection.Open();
                Result = await connection.ExecuteAsync(sp, parm, commandType: commandType);
            }
            return Result;
        }
        public async Task<T> GetAsync<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetDbConnection();
            db.Open();
            return await db.QueryFirstOrDefaultAsync<T>(sp, parms, commandType: commandType);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetDbConnection();
            db.Open();
            return await db.QueryAsync<T>(sp, parms, commandType: commandType);
        }
    }
}
