using AutoMapper;
using Moq;
using TCCS.Application.Services;
using TCCS.Application.ViewModels;
using TCCS.DataAccess.Interfaces;
using TCCS.DataAccess.Models;

namespace TCCS.Application.UnitTesting
{
    public class EmployeeServiceTest
    {
        private static IMapper _mapper;
        public EmployeeServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new EmployeeMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async Task GetAllEmployee_ShouldReturnList()
        {
            //Arrange
            var employeeModelList = GetEmployeeModelList();
            var employeeList = _mapper.Map<IEnumerable<Employee>>(employeeModelList);


            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.GetAllEmployee()).ReturnsAsync(employeeList);

            var service = new EmployeeService(mockRepo.Object, _mapper);

            //Act
            var result = await service.GetAllEmployee();

            //Assert
            Assert.IsAssignableFrom<List<EmployeeModel>>(result);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetEmployeeById_ShouldReturnList()
        {
            //Arrange
            int id = 1;

            var employeeModel = GetEmployeeModel();
            var employee = _mapper.Map<Employee>(employeeModel);



            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.GetEmployeeById(id)).ReturnsAsync(employee);

            var service = new EmployeeService(mockRepo.Object, _mapper);

            //Act
            var result = await service.GetEmployeeById(id);

            //Assert
            Assert.IsAssignableFrom<EmployeeModel>(result);
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task GetEmployeeByIdUsingPredicate_ShouldReturnList()
        {
            //Arrange
            int id = 1;
            var employeeModelList = GetEmployeeModelListByPredication(id);
            var employeeList = _mapper.Map<IEnumerable<Employee>>(employeeModelList);


            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.GetEmployeeById(x => x.Id == id)).ReturnsAsync(employeeList);

            var service = new EmployeeService(mockRepo.Object, _mapper);
            //Act
            var result = await service.GetEmployeeById(x => x.Id == id);

            //Assert
            Assert.IsAssignableFrom<IEnumerable<EmployeeModel>>(result);
            Assert.NotNull(result);
        }


        [Fact]
        public async Task AddEmployeeAsync_ShouldSaveEmployee()
        {
            //Arrange
            var employeeModel = GetEmployeeModel();
            var employee = _mapper.Map<Employee>(employeeModel);


            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.AddEmployeeAsync(employee)).ReturnsAsync(employee);
            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var service = new EmployeeService(mockRepo.Object, _mapper);
            //Act
            var result = await service.AddEmployeeAsync(employeeModel);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task UpdateEmployee_ShouldSaveEmployee()
        {
            //Arrange
            var employeeModel = GetEmployeeModel();
            var employee = _mapper.Map<Employee>(employeeModel);

            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.UpdateEmployee(employee)).Returns(employee);
            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var service = new EmployeeService(mockRepo.Object, _mapper);

            //Act
            var result = service.UpdateEmployee(employeeModel);

            //Assert
            Assert.Equal(1, result.Result);
        }

        [Fact]
        public async Task RemoveEmployee_ShouldRemoveEmployee()
        {
            //Arrange
            var employeeModel = GetEmployeeModel();
            var employee = _mapper.Map<Employee>(employeeModel);

            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.RemoveEmployee(employee));
            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var service = new EmployeeService(mockRepo.Object, _mapper);

            //Act
            var result = service.RemoveEmployee(employeeModel);

            //Assert
            Assert.Equal(1, result.Result);
        }

        [Fact]
        public async Task RemoveEmployeeById_ShouldRemoveEmployee()
        {
            //Arrange
            var employeeModel = GetEmployeeModel();
            var employee = _mapper.Map<Employee>(employeeModel);

            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.RemoveEmployeeById(1));
            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var service = new EmployeeService(mockRepo.Object, _mapper);

            //Act
            var result = service.RemoveEmployeeById(1);

            //Assert
            Assert.Equal(1, result.Result);
        }

        [Fact]
        public async Task SingleOrDefaultEmployeeAsync_ShouldReturn()
        {
            //Arrange
            var employeeModel = GetEmployeeModel();
            var employee = _mapper.Map<Employee>(employeeModel);

            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.SingleOrDefaultEmployeeAsync(x => x.Id == 1)).ReturnsAsync(employee);

            var service = new EmployeeService(mockRepo.Object, _mapper);

            //Act
            var result = service.SingleOrDefaultEmployeeAsync(x => x.Id == 1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task FirstOrDefaultEmployeeAsync_ShouldReturn()
        {
            //Arrange
            var employeeModel = GetEmployeeModel();
            var employee = _mapper.Map<Employee>(employeeModel);

            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.FirstOrDefaultEmployeeAsync(x => x.Id == 1)).ReturnsAsync(employee);

            var service = new EmployeeService(mockRepo.Object, _mapper);

            //Act
            var result = service.FirstOrDefaultEmployeeAsync(x => x.Id == 1);

            //Assert
            Assert.NotNull(result);
        }



        [Fact]
        public async Task AddEmployeeRange_ShouldSaveEmployee()
        {
            //Arrange
            var employeeListModel = GetEmployeeModelList();
            var employeeList = _mapper.Map<List<Employee>>(employeeListModel);


            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.AddEmployeeRange(employeeList));
            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var service = new EmployeeService(mockRepo.Object, _mapper);
            //Act
            var result = await service.AddEmployeeRange(employeeListModel);

            //Assert
            Assert.Equal(1, result);
        }


        [Fact]
        public async Task AddEmployeeRangeAsync_ShouldSaveEmployee()
        {
            //Arrange
            var employeeListModel = GetEmployeeModelList();
            var employeeList = _mapper.Map<List<Employee>>(employeeListModel);


            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.AddEmployeeRangeAsync(employeeList));
            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var service = new EmployeeService(mockRepo.Object, _mapper);
            //Act
            var result = await service.AddEmployeeRangeAsync(employeeListModel);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task UpdateEmployeeRange_ShouldSaveEmployee()
        {
            //Arrange
            var employeeListModel = GetEmployeeModelList();
            var employeeList = _mapper.Map<List<Employee>>(employeeListModel);


            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.UpdateEmployeeRange(employeeList));
            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var service = new EmployeeService(mockRepo.Object, _mapper);
            //Act
            var result = await service.UpdateEmployeeRange(employeeListModel);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task RemoveEmployeeRange_ShouldSaveEmployee()
        {
            //Arrange
            var employeeListModel = GetEmployeeModelList();
            var employeeList = _mapper.Map<List<Employee>>(employeeListModel);


            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.RemoveEmployeeRange(employeeList));
            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var service = new EmployeeService(mockRepo.Object, _mapper);
            //Act
            var result = await service.RemoveEmployeeRange(employeeListModel);

            //Assert
            Assert.Equal(1, result);
        }






        private IEnumerable<EmployeeModel> GetEmployeeModelList()
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>()
            {
                new EmployeeModel{Id=1,Name="test1",EmailId="test1@gmail.com"},
                new EmployeeModel{Id=2,Name="test2",EmailId="test2@gmail.com"}
            };

            return employeeList;
        }

        private IEnumerable<EmployeeModel> GetEmployeeModelListByPredication(int id)
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>()
            {
                new EmployeeModel{Id=1,Name="test1",EmailId="test1@gmail.com"},
                new EmployeeModel{Id=2,Name="test2",EmailId="test2@gmail.com"}
            };

            return employeeList.Where(x => x.Id == id).ToList();
        }

        private EmployeeModel GetEmployeeModel()
        {
            EmployeeModel employee = new EmployeeModel()
            {
                Id = 1,
                Name = "test1",
                EmailId = "test1@gmail.com"
            };

            return employee;
        }

        private EmployeeModel AddEmployeeModel()
        {
            EmployeeModel employee = new EmployeeModel()
            {
                Id = 0,
                Name = "abc",
                EmailId = "abc@gmail.com"
            };

            return employee;
        }
    }
}
