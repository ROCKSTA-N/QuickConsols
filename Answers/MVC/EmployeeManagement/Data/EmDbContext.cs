using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EmDbContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<HighestSalaryDepartment> HighestSalaryDepartment { get; set; }
        public virtual DbSet<Millennial> Millennials { get; set; }
        public virtual DbSet<DepartmentAverageSalaryStats> DepartmentAverageSalaryStats { get; set; }
        public virtual DbSet<EmployeeSalaryIncrease> EmployeeSalaryIncreases { get; set; }
        public EmDbContext(DbContextOptions<EmDbContext> options) : base(options)
        {
        }
    }
}
