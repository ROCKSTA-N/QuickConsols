using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class EmployeeService  : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public IEnumerable<DepartmentAverageSalaryStatsDto> GetDepartmentAverageSalaryStats()
        {
            var stats = _employeeRepository.GetDepartmentAverageSalaryStats();
            foreach (var stat in stats)
                yield return _mapper.Map<DepartmentAverageSalaryStatsDto>(stat);
        }
        public IEnumerable<EmployeeSalaryIncreaseDto> GetEmployeeSalaryIncrease()
        {
            var employeeSalaryIncreases = _employeeRepository.GetEmployeeSalaryIncrease();
            foreach (var employee in employeeSalaryIncreases)
                yield return _mapper.Map<EmployeeSalaryIncreaseDto>(employee);
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            foreach (var employee in employees)
                yield return _mapper.Map<EmployeeDto>(employee);
        }  
        
        public IEnumerable<MillennialDto> GetMillennials()
        {
            var millennials = _employeeRepository.GetMillennials();
            foreach (var millennial in millennials)
                yield return _mapper.Map<MillennialDto>(millennial);
        }

        public HighestSalaryDepartmentDto GetHighestSalaryDepartment()
        {
            var department = _employeeRepository.GetHighestSalaryDepartment(); 
            return _mapper.Map<HighestSalaryDepartmentDto>(department);
        }
    }
}
