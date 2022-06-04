using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("EmployeeSalaryIncrease")]
    public class EmployeeSalaryIncrease
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Departnemt { get; set; }
        public decimal Salary { get; set; }
        public decimal Increase { get; set; }
    }
}
