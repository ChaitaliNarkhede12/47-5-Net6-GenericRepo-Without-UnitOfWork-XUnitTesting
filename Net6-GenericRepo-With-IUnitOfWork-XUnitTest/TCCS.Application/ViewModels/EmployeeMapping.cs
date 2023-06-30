using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Models;

namespace TCCS.Application.ViewModels
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            CreateMap<EmployeeModel, Employee>();
            CreateMap<Employee, EmployeeModel>();
        }
    }
}
