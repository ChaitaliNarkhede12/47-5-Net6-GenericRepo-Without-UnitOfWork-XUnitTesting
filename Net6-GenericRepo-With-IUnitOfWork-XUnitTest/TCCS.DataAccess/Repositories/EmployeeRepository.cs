using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Interfaces;
using TCCS.DataAccess.Models;

namespace TCCS.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        IRepository<Employee,int> _repository;
        public EmployeeRepository(IRepository<Employee,int> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _repository.GetAll();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeById(Expression<Func<Employee, bool>> predicate)
        {
            return await _repository.GetById(predicate);
        }


        public async Task<Employee> AddEmployeeAsync(Employee entity)
        {
            return await _repository.AddAsync(entity);
        }

        public Employee UpdateEmployee(Employee entity)
        {
            return _repository.Update(entity);
        }

        public void RemoveEmployee(Employee entity)
        {
            _repository.Remove(entity);
        }

        public async Task RemoveEmployeeById(int id)
        {
            await _repository.RemoveById(id);
        }



        public int SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _repository.SaveChangesAsync();
        }



        public async Task<Employee> SingleOrDefaultEmployeeAsync(Expression<Func<Employee, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public async Task<Employee> FirstOrDefaultEmployeeAsync(Expression<Func<Employee, bool>> predicate)
        {
            return await _repository.FirstOrDefaultAsync(predicate);
        }



        public void AddEmployeeRange(IEnumerable<Employee> entities)
        {
            _repository.AddRange(entities);
        }

        public async Task AddEmployeeRangeAsync(IEnumerable<Employee> entities)
        {
            await _repository.AddRangeAsync(entities);
        }

        public void UpdateEmployeeRange(IEnumerable<Employee> entities)
        {
            _repository.UpdateRange(entities);
        }

        public void RemoveEmployeeRange(IEnumerable<Employee> entities)
        {
            _repository.RemoveRange(entities);
        }
    }
}
