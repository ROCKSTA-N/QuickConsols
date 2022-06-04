using Application.Models;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Millennial, MillennialDto>();
            CreateMap<HighestSalaryDepartment, HighestSalaryDepartmentDto>();
            CreateMap<DepartmentAverageSalaryStats, DepartmentAverageSalaryStatsDto>();
            CreateMap<EmployeeSalaryIncrease, EmployeeSalaryIncreaseDto>();
            CreateMap<Employee, EmployeeDto>()
                 .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
        }
    }
}
