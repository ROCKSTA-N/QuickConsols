using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee> {

        IEnumerable<Employee> GetAllEmployees();
        HighestSalaryDepartment GetHighestSalaryDepartment();
        IEnumerable<DepartmentAverageSalaryStats> GetDepartmentAverageSalaryStats();
        IEnumerable<EmployeeSalaryIncrease> GetEmployeeSalaryIncrease();
        IEnumerable<Millennial> GetMillennials();
    }

}
