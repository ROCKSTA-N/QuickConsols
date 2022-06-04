using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("HighestSalaryDepartment")]
    public class HighestSalaryDepartment
    {
        public string Department { get; set; }
        public int Id { get; set; } 
        public decimal Salary { get; set; }
    }
}
