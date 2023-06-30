using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCS.Application.ViewModels;
using TCCS.DataAccess.Models;

namespace TCCS.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetAllEmployee();
        Task<EmployeeModel> GetEmployeeById(int id);
        Task<IEnumerable<EmployeeModel>> GetEmployeeById(Expression<Func<Employee, bool>> predicate);
        Task<int> AddEmployeeAsync(EmployeeModel entity);
        Task<int> UpdateEmployee(EmployeeModel entity);
        Task<int> RemoveEmployee(EmployeeModel entity);
        Task<int> RemoveEmployeeById(int id);

        Task<EmployeeModel> SingleOrDefaultEmployeeAsync(Expression<Func<Employee, bool>> predicate);
        Task<EmployeeModel> FirstOrDefaultEmployeeAsync(Expression<Func<Employee, bool>> predicate);

        Task<int> AddEmployeeRange(IEnumerable<EmployeeModel> entities);
        Task<int> AddEmployeeRangeAsync(IEnumerable<EmployeeModel> entities);

        Task<int> UpdateEmployeeRange(IEnumerable<EmployeeModel> entities);

        Task<int> RemoveEmployeeRange(IEnumerable<EmployeeModel> entities);
    }
}
