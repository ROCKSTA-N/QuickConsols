namespace Application.Models
{
    public class DepartmentAverageSalaryStatsDto
    {
        public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
        public decimal AverageSalary { get; set; }
    }
}
