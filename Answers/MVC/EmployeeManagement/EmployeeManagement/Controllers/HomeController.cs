using Application.Interfaces;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployees();
            return View(employees);
        } 
        
        public IActionResult DepartmentAverageSalaryStats()
        {
            var stats = _employeeService.GetDepartmentAverageSalaryStats(); 
            return View(stats);
        }

        public IActionResult HighestSalaryDepartment()
        {
            var stats = _employeeService.GetHighestSalaryDepartment();
            return View(stats);
        }

        public IActionResult EmployeeSalaryIncrease()
        {
            var stats = _employeeService.GetEmployeeSalaryIncrease();
            return View(stats);
        }

        public IActionResult Millennials()
        {
            var stats = _employeeService.GetMillennials();
            return View(stats);
        }
    }
}
