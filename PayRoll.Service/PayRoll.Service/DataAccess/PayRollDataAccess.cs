using Dapper;
using PayRoll.Service.DBContext;
using PayRoll.Service.Models;
using System.Data;

namespace PayRoll.Service.DataAccess
{
    public class PayRollDataAccess : IPayRollDataAccess
    {
        private readonly IDBContext _dbcontext;
        public PayRollDataAccess(IDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> PayRoll(Salary salary)
        {
          
            var parameters = new DynamicParameters();
            parameters.Add("EmpId", salary.EmpId);
            parameters.Add("Salaried", salary.Salaried);
            parameters.Add("CreatedBy", salary.CreatedBy);

            var result = await _dbcontext.ExecuteAsync("Proc_AddPayRoll", parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<IList<Salary>> GetAllPayRoll()
        {
            var result = await _dbcontext.GetAllAsync<Salary>("proc_GetAllPayRoll",null, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task<PayRollRecord> GetPayRollById(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id",Id);
            var result = await _dbcontext.GetAsync<PayRollRecord>("Proc_GetPayRollById", parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<int> DeletePayRollById(int  id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id",id);
            var result = await _dbcontext.ExecuteAsync("Proc_DeletePayRollById", parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<int> UpdatePayRollById(int Id,UpdatePayRollRecords updatePayRollRecords)
            {  
            var parameters = new DynamicParameters();
            parameters.Add("Id",Id);
            parameters.Add("Empid", updatePayRollRecords.EmpId);
            parameters.Add("Salaried", updatePayRollRecords.Salaried);
            parameters.Add("CreatedBy", updatePayRollRecords.CreatedBy);
            var result = await _dbcontext.ExecuteAsync("proc_UpdatePayRollById", parameters,commandType: CommandType.StoredProcedure);
            return result;
        }

      }
}
