using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCS.Application.Interfaces;
using TCCS.Application.ViewModels;
using TCCS.DataAccess.Interfaces;
using TCCS.DataAccess.Models;

namespace TCCS.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, 
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            try
            {
                var employees = await _employeeRepository.GetAllEmployee();
                var res = _mapper.Map<List<EmployeeModel>>(employees);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeById(id);
                return _mapper.Map<EmployeeModel>(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeeById(Expression<Func<Employee, bool>> predicate)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeById(predicate);
                return _mapper.Map<IEnumerable<EmployeeModel>>(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<int> AddEmployeeAsync(EmployeeModel entity)
        {
            try
            {
                var employee = _mapper.Map<Employee>(entity);
                var data = await _employeeRepository.AddEmployeeAsync(employee);

                int result = await _employeeRepository.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateEmployee(EmployeeModel entity)
        {
            try
            {
                var employee = _mapper.Map<Employee>(entity);
                var data = _employeeRepository.UpdateEmployee(employee);

                int result = await _employeeRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> RemoveEmployee(EmployeeModel entity)
        {
            try
            {
                var employee = _mapper.Map<Employee>(entity);
                _employeeRepository.RemoveEmployee(employee);

                int result = await _employeeRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> RemoveEmployeeById(int id)
        {
            try
            {
                await _employeeRepository.RemoveEmployeeById(id);
                int result = await _employeeRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public async Task<EmployeeModel> SingleOrDefaultEmployeeAsync(Expression<Func<Employee, bool>> predicate)
        {
            try
            {
                Employee employee = await _employeeRepository.SingleOrDefaultEmployeeAsync(predicate);
                return _mapper.Map<EmployeeModel>(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmployeeModel> FirstOrDefaultEmployeeAsync(Expression<Func<Employee, bool>> predicate)
        {
            try
            {
                var employee = await _employeeRepository.FirstOrDefaultEmployeeAsync(predicate);
                return _mapper.Map<EmployeeModel>(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public async Task<int> AddEmployeeRange(IEnumerable<EmployeeModel> entities)
        {
            try
            {
                var employees = _mapper.Map<IEnumerable<Employee>>(entities);
                _employeeRepository.AddEmployeeRange(employees);

                int result = await _employeeRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> AddEmployeeRangeAsync(IEnumerable<EmployeeModel> entities)
        {
            try
            {
                var employees = _mapper.Map<IEnumerable<Employee>>(entities);
                await _employeeRepository.AddEmployeeRangeAsync(employees);

                int result = await _employeeRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateEmployeeRange(IEnumerable<EmployeeModel> entities)
        {
            try
            {
                var employees = _mapper.Map<IEnumerable<Employee>>(entities);
                _employeeRepository.UpdateEmployeeRange(employees);

                int result = await _employeeRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> RemoveEmployeeRange(IEnumerable<EmployeeModel> entities)
        {
            try
            {
                var employees = this._mapper.Map<IEnumerable<Employee>>(entities);
                this._employeeRepository.RemoveEmployeeRange(employees);

                int result = await _employeeRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
