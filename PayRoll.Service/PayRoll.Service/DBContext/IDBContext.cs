using Dapper;
using System.Data;

namespace PayRoll.Service.DBContext
{
    public interface IDBContext
    {
        Task<int> ExecuteAsync(string sp, DynamicParameters parm = null, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.StoredProcedure);
        Task<T> GetAsync<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.StoredProcedure);
    }
}
