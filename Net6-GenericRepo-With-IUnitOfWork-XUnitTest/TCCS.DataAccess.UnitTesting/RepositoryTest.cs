using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Models;
using TCCS.DataAccess.Repositories;
using TCCS.UnitTesting.Core;
using TCCS.UnitTesting.Core.MoqData;

namespace TCCS.DataAccess.UnitTesting
{
    public class RepositoryTest : IClassFixture<TCCSDataFixture>, IDisposable
    {
        TCCSDataFixture fixture;

        public RepositoryTest(TCCSDataFixture fixture)
        {
            this.fixture = fixture;
        }


        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            var employee = GetEmployee();
            var employeeMoq = new EmployeeMoq(fixture);
            employeeMoq.MoqData(employee);

            var repo = new Repository<Employee,int>(fixture.tccsContext);

            var res = await repo.GetAll();

            Assert.Equal(1, res.Count());
        }

        [Fact]
        public async Task GetById_ShouldReturn()
        {
            var employee = GetEmployee();
            var employeeMoq = new EmployeeMoq(fixture);
            employeeMoq.MoqData(employee);

            var repo = new Repository<Employee, int>(fixture.tccsContext);

            var res = await repo.GetById(1);

            Assert.IsAssignableFrom<Employee>(res); 
        }

        [Fact]
        public async Task GetByIdWithPredicate_ShouldReturn()
        {
            var employee = GetEmployee();
            var employeeMoq = new EmployeeMoq(fixture);
            employeeMoq.MoqData(employee);

            var repo = new Repository<Employee, int>(fixture.tccsContext);

            var res = await repo.GetById(x => x.Id == 1);

            Assert.Equal(1, res.Count());
        }

        [Fact]
        public async Task AddAsync_ShouldReturn()
        {
            var employee = GetEmployee();
            var employeeMoq = new EmployeeMoq(fixture);
            employeeMoq.MoqData(employee);

            var repo = new Repository<Employee, int>(fixture.tccsContext);

            var res = await repo.AddAsync(new Employee { Name="Test",EmailId="test@gmail.com"});

            Assert.IsAssignableFrom<Employee>(res);
        }

        [Fact]
        public async Task Update_ShouldReturn()
        {
            var employee = GetEmployee();
            var employeeMoq = new EmployeeMoq(fixture);
            employeeMoq.MoqData(employee);

            var repo = new Repository<Employee, int>(fixture.tccsContext);

            var res = repo.Update(new Employee {Id=1, Name = "Test", EmailId = "test@gmail.com" });

            Assert.IsAssignableFrom<Employee>(res);
        }


        [Fact]
        public async Task Remove_ShouldReturn()
        {
            var employee = GetEmployee();
            var employeeMoq = new EmployeeMoq(fixture);
            employeeMoq.MoqData(employee);

            var repo = new Repository<Employee, int>(fixture.tccsContext);

            repo.Remove(new Employee { Id = 1, Name = "Test", EmailId = "test@gmail.com" });
        }

        [Fact]
        public async Task RemoveById_ShouldReturn()
        {
            var employee = GetEmployee();
            var employeeMoq = new EmployeeMoq(fixture);
            employeeMoq.MoqData(employee);

            var repo = new Repository<Employee, int>(fixture.tccsContext);

            repo.RemoveById(1);
        }



        public void Dispose()
        {
            fixture.tccsContext.Database.EnsureDeleted();
        }




        private IEnumerable<Employee> GetEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee{Id=1,Name="test1",EmailId="test1@gmail.com"},
                new Employee{Id=2,Name="test2",EmailId="test2@gmail.com"},
                new Employee{Id=3,Name="test3",EmailId="test3@gmail.com"},
                new Employee{Id=4,Name="test4",EmailId="test4@gmail.com"},
            };

            return employeeList;
        }


        private Employee GetEmployee()
        {
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "test1",
                EmailId = "test1@gmail.com"
            };

            return employee;
        }
    }
}
