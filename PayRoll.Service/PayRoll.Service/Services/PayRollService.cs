using PayRoll.Service.DataAccess;
using PayRoll.Service.Models;

namespace PayRoll.Service.Services
{
    public class PayRollService : IPayRollService
    {
        private readonly IPayRollDataAccess _payRollDataAccess;
        public PayRollService(IPayRollDataAccess payRollDataAccess)
        {
            _payRollDataAccess = payRollDataAccess;
        }

        public async Task<int> PayRoll(Salary salary)
        {
            return await _payRollDataAccess.PayRoll(salary);
        }
        public async Task<IList<Salary>> GetAllPayRoll()
        {
            return await _payRollDataAccess.GetAllPayRoll();
        }
        public async Task<PayRollRecord> GetPayRollById(int Id)
        {
            return await _payRollDataAccess.GetPayRollById(Id);
        }
        public async Task<int> DeletePayRollById(int Id)
        {
            return await _payRollDataAccess.DeletePayRollById(Id);
        }
        public async Task<int> UpdatePayRollById(int Id, UpdatePayRollRecords updatePayRollRecords)
        {
            return await _payRollDataAccess.UpdatePayRollById(Id, updatePayRollRecords);
        }
    }
}
