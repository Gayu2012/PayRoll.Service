using System.ComponentModel.DataAnnotations;

namespace PayRoll.Service.Models
{
    public class Salary
    {
        [Required(ErrorMessage = "Employee ID is required.")]
        public int EmpId {   get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1, 1000000, ErrorMessage = "Salary must be between 1 and 1,000,000.")]
        public int Salaried { get; set; }

        [Required(ErrorMessage = "Created By is required.")]
        public int CreatedBy { get; set; }
    }
}
