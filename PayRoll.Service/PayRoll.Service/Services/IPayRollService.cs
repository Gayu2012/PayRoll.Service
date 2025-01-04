using PayRoll.Service.Models;

namespace PayRoll.Service.Services
{
    public interface IPayRollService
    {
        Task<int> PayRoll(Salary payroll);
        Task<IList<Salary>> GetAllPayRoll();
        Task<PayRollRecord> GetPayRollById(int Id);
        Task<int> DeletePayRollById(int Id);
        Task<int> UpdatePayRollById(int Id,UpdatePayRollRecords updatePayRollRecords);
    }
}
