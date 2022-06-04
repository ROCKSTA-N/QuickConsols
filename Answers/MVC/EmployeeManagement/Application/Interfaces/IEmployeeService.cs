using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees();
        IEnumerable<MillennialDto> GetMillennials();
        HighestSalaryDepartmentDto GetHighestSalaryDepartment();
        IEnumerable<EmployeeSalaryIncreaseDto> GetEmployeeSalaryIncrease();
        IEnumerable<DepartmentAverageSalaryStatsDto> GetDepartmentAverageSalaryStats();
    }
}
