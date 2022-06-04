using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("DepartmentAverageSalaryStats")]
    public class DepartmentAverageSalaryStats
    {
        public string DepartmentName { get; set; }
        public int Id { get; set; }
        public int EmployeeCount { get; set; }
        public decimal AverageSalary { get; set; }
    } 
}
