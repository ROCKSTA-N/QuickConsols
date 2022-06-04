using System;

namespace Application.Models
{
    public class EmployeeSalaryIncreaseDto
    {
        public string DepartmentName { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public decimal Increase { get; set; }
    }
}
