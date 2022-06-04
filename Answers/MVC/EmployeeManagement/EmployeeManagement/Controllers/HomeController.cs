using Application.Interfaces;
using Application.Models;
using CsvHelper;
using CsvHelper.Configuration;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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


        public IActionResult CreateEmployee()
        {
            var stats = _employeeService.GetMillennials();
            return View(stats);
        }


        public IActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            
            return View(stats);
        }


        public ActionResult Export( string fileName)
        { 
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
            using MemoryStream ms = new();
            using StreamWriter sw = new(stream: ms, encoding: new UTF8Encoding(true));
            using var cw = new CsvWriter(sw, cc);

            switch (fileName)
            {
                case "EmployeeSalaryIncrease":
                    var stats = _employeeService.GetEmployeeSalaryIncrease();
                    cw.WriteRecords(stats);
                    break;


                case "HighestSalaryDepartment":
                    var data = _employeeService.GetHighestSalaryDepartment();
                    var list = new List<HighestSalaryDepartmentDto>
                    {
                        data
                    };
                    cw.WriteRecords(list);
                    break;

                    
                case "DepartmentAverageSalaryStats":
                    var averageSalaryStatsDtos = _employeeService.GetDepartmentAverageSalaryStats();
                    cw.WriteRecords(averageSalaryStatsDtos);
                    break;



                case "Employees":
                    var employees = _employeeService.GetEmployees();
                    cw.WriteRecords(employees);
                    break;



                case "Millennials":
                    var millennialDtos = _employeeService.GetMillennials();
                    cw.WriteRecords(millennialDtos);
                    break;
                default:
                    // code block
                    break;
            }
            

            return File(ms.ToArray(), "application/octet-stream", $"{fileName}_export_{DateTime.UtcNow.Ticks}.csv");
        }

        
    }
}
