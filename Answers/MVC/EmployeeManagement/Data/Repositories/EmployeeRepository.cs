using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(EmDbContext context) : base(context)
        {
            DbContext = context;
        }

        private readonly EmDbContext DbContext;

        public IEnumerable<Employee> GetAllEmployees()
        {
            return DbSet.Where(x => x.Id > 0).Include(x => x.Department);
        }

        public IEnumerable<DepartmentAverageSalaryStats> GetDepartmentAverageSalaryStats()
        {
            var sql = @"
                    WITH 
	                    #TEMP (totalSalary, numberOfEmp , departmentId) 
	                     as (SELECT  SUM(salary), COUNT(*) ,  departmentId 
	                     FROM employees GROUP BY departmentId)

                    SELECT  DEP.id 'Id' , DEP.name 'DepartmentName', 
                    IIF(#TEMP.numberOfEmp IS NULL,0,#TEMP.numberOfEmp)
                     'EmployeeCount'  , IIF((#TEMP.totalSalary / #TEMP.numberOfEmp) IS NULL,0,
					                    (#TEMP.totalSalary / #TEMP.numberOfEmp)) AverageSalary
                    FROM departments DEP LEFT JOIN #TEMP
                    ON #TEMP.departmentId = DEP.id
                    ORDER BY AverageSalary
            "; 
            return DbContext.DepartmentAverageSalaryStats.FromSqlRaw(sql); ;
        }


        public IEnumerable<EmployeeSalaryIncrease> GetEmployeeSalaryIncrease()
        {
            var sql = @"
                    SELECT EMP.Id 'Id', FirstName , LastName , 
                    DEP.name 'Departnemt' , Salary , salary + (salary * 0.01) Increase
                    FROM employees EMP 
                    INNER JOIN departments DEP 
                    ON EMP.departmentId = DEP.id
                    ORDER BY increase
            ";
             
            return DbContext.EmployeeSalaryIncreases.FromSqlRaw(sql); ;
        }

        public HighestSalaryDepartment GetHighestSalaryDepartment()
        {
            var sql = @"
                    WITH 
	                    #TEMP (totalSalary, departmentId) 
	                     as (SELECT  SUM(salary), departmentId 
	                     FROM employees GROUP BY departmentId)

                        SELECT TOP 1 MAX(totalSalary) 'Salary' , DEP.name 'Department' , DEP.id 'Id'
                        FROM departments DEP INNER JOIN #TEMP
                        ON #TEMP.departmentId = DEP.id
                        GROUP BY  DEP.name
                        ORDER BY MAX(totalSalary) DESC
            ";

            var department = DbContext.HighestSalaryDepartment.FromSqlRaw(sql);

            return department.First();
        } 
        
        public IEnumerable<Millennial> GetMillennials()
        {
            var sql = @"
                   SELECT Id, FirstName , LastName , 
                    IIF(dateOfBirth between DATEFROMPARTS(1981,1,1) and DATEFROMPARTS(1996,1,1),'Yes', 'No') IsMillennial
                    FROM employees  

            ";

            return DbContext.Millennials.FromSqlRaw(sql);
        }
    }
}
