using PayRoll.Service.Models;
using PayRoll.Service.Services;

namespace PayRoll.Service.DataAccess
{
    public interface IPayRollDataAccess
    {
       Task<int> PayRoll(Salary payroll);
       Task<IList<Salary>> GetAllPayRoll();
       Task<PayRollRecord> GetPayRollById(int Id);
       Task<int> DeletePayRollById(int id);
       Task<int> UpdatePayRollById(int Id, UpdatePayRollRecords updatePayRollRecords);
    }
}
