using Microsoft.AspNetCore.Mvc;
using PayRoll.Service.Models;
using PayRoll.Service.Services;

namespace PayRoll.Service.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PayRollController : ControllerBase
    {
        private readonly IPayRollService _payrollservice;

        public PayRollController(IPayRollService payrollservice)
        {
            _payrollservice = payrollservice;
        }

        [HttpPost]
        public async Task<IActionResult> PayRoll(Salary salary)
        {
            var result = await _payrollservice.PayRoll(salary);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayRoll()
        {
            var result = await _payrollservice.GetAllPayRoll();
            return Ok(result);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetPayRollById([FromRoute] int Id)
        {
            var result = await _payrollservice.GetPayRollById(Id);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePayRollById(int Id)
        {
            var result = await _payrollservice.DeletePayRollById(Id);
            return NoContent();
        }
        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdatePayRollById([FromRoute] int Id, [FromBody] UpdatePayRollRecords updatePayRollRecords)
        {
            var result = await _payrollservice.UpdatePayRollById(Id, updatePayRollRecords);
            return Ok(result);
        }
    }
}
