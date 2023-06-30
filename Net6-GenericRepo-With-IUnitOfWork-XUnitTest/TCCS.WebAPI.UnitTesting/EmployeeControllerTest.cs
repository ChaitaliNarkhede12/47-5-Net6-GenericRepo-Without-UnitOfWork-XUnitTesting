using Microsoft.AspNetCore.Mvc;
using Moq;
using TCCS.Application.Interfaces;
using TCCS.Application.ViewModels;
using TCCS.WebAPI.Controllers;

namespace TCCS.WebAPI.UnitTesting
{
    public class EmployeeControllerTest
    {
        [Fact]
        public async Task GetAllEmployee_ReturnOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(x => x.GetAllEmployee()).ReturnsAsync(GetEmployeeModelList());

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.GetAllEmployee();

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEmployeeById_ReturnOkResult()
        {
            // Arrange
            int id = 1;
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.GetEmployeeById(id)).ReturnsAsync(GetEmployeeModelById(id));

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.GetEmployeeById(id);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEmployeeById_ReturnNoContent()
        {
            // Arrange
            int id = 10;
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.GetEmployeeById(id)).ReturnsAsync(GetEmployeeModelById(id));

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.GetEmployeeById(id);

            //// Assert
            Assert.Equal(204, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetEmployeeByIdUsingPredicate_ReturnOkResult()
        {
            // Arrange
            int id = 1;
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.GetEmployeeById(x => x.Id == id)).ReturnsAsync(GetEmployeeModelUsingPredicate(id));

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.GetEmployeeByIdUsingPredicate(id);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEmployeeSignleOrDefault_ReturnOkResult()
        {
            // Arrange
            int id = 1;
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.SingleOrDefaultEmployeeAsync(x => x.Id == id)).ReturnsAsync(GetEmployeeSingleOrDefault(id));

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.GetEmployeeSignleOrDefault(id);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEmployeeSignleOrDefault_ReturnNoContent()
        {
            // Arrange
            int id = 10;
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.SingleOrDefaultEmployeeAsync(x => x.Id == id)).ReturnsAsync(GetEmployeeSingleOrDefault(id));

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.GetEmployeeSignleOrDefault(id);

            //// Assert
            Assert.Equal(204, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetEmployeeFirstOrDefault_ReturnOkResult()
        {
            // Arrange
            int id = 1;
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.FirstOrDefaultEmployeeAsync(x => x.Id == id)).ReturnsAsync(GetEmployeeFirstOrDerfault(id));

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.GetEmployeeFirstOrDefault(id);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEmployeeFirstOrDefault_ReturnNoContent()
        {
            // Arrange
            int id = 10;
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.FirstOrDefaultEmployeeAsync(x => x.Id == id)).ReturnsAsync(GetEmployeeFirstOrDerfault(id));

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.GetEmployeeFirstOrDefault(id);

            //// Assert
            Assert.Equal(204, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task AddEmployeeAsync_ReturnOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeService>();
            var addEmployee = AddEmployeeModel();

            mockRepo.Setup(repo => repo.AddEmployeeAsync(addEmployee)).ReturnsAsync(1);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.AddEmployeeAsync(addEmployee);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddEmployeeAsync_ReturnBadRequest()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeService>();
            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.AddEmployeeAsync(null);

            //// Assert
            Assert.Equal(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_ReturnOkResult()
        {
            // Arrange
            int id = 1;
            var mockRepo = new Mock<IEmployeeService>();
            var updateEmployee = GetEmployeeModelById(id);

            mockRepo.Setup(repo => repo.UpdateEmployee(updateEmployee)).ReturnsAsync(1);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.UpdateEmployee(updateEmployee);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_ReturnBadRequest()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeService>();
            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.UpdateEmployee(null);

            //// Assert
            Assert.Equal(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task RemoveEmployeeAsync_ReturnOkResultWithSucess()
        {
            // Arrange
            int id = 1;
            int returnData = 1;
            var mockRepo = new Mock<IEmployeeService>();
            var employee = GetEmployeeModelById(id);

            mockRepo.Setup(repo => repo.RemoveEmployee(employee)).ReturnsAsync(returnData);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.RemoveEmployee(employee);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }

        [Fact]
        public async Task RemoveEmployeeAsync_ReturnOkResultWithNotSucess()
        {
            // Arrange
            int id = 1;
            int returnData = 0;
            var mockRepo = new Mock<IEmployeeService>();
            var employee = GetEmployeeModelById(id);

            mockRepo.Setup(repo => repo.RemoveEmployee(employee)).ReturnsAsync(returnData);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.RemoveEmployee(employee);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(0, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }

        [Fact]
        public async Task RemoveEmployeeAsync_ReturnBadRequest()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeService>();
            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.RemoveEmployee(null);

            //// Assert
            Assert.Equal(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task RemoveEmployeeById_ReturnOkResultWithSucess()
        {
            // Arrange
            int returnData = 1;
            int id = 1;
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.RemoveEmployeeById(id)).ReturnsAsync(returnData);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.RemoveEmployeeById(id);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }

        [Fact]
        public async Task RemoveEmployeeById_ReturnOkResultWithNotSucess()
        {
            // Arrange
            int returnData = 0;
            int id = 1;
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.RemoveEmployeeById(id)).ReturnsAsync(returnData);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.RemoveEmployeeById(id);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(0, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }

        [Fact]
        public async Task RemoveEmployeeById_ReturnBadRequest()
        {
            // Arrange
            int id = 0;
            var mockRepo = new Mock<IEmployeeService>();
            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.RemoveEmployeeById(id);

            //// Assert
            Assert.Equal(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<BadRequestResult>(result);
        }



        [Fact]
        public async Task AddEmployeeRange_ReturnOkResult()
        {
            // Arrange
            int output = 1;
            var mockRepo = new Mock<IEmployeeService>();
            var addEmployeeList = GetEmployeeModelList();

            mockRepo.Setup(repo => repo.AddEmployeeRange(addEmployeeList)).ReturnsAsync(output);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.AddEmployeeRange(addEmployeeList);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddEmployeeRange_ReturnBadRequest()
        {
            // Arrange
            int output = 1;
            var mockRepo = new Mock<IEmployeeService>();
            var addEmployeeList = GetEmployeeModelList();

            mockRepo.Setup(repo => repo.AddEmployeeRange(addEmployeeList)).ReturnsAsync(output);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.AddEmployeeRange(null);

            //// Assert
            Assert.Equal(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task AddEmployeeRangeAsync_ReturnOkResult()
        {
            // Arrange
            int output = 1;
            var mockRepo = new Mock<IEmployeeService>();
            var addEmployeeList = GetEmployeeModelList();

            mockRepo.Setup(repo => repo.AddEmployeeRangeAsync(addEmployeeList)).ReturnsAsync(output);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.AddEmployeeRangeAsync(addEmployeeList);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddEmployeeRangeAsync_ReturnBadRequest()
        {
            // Arrange
            int output = 1;
            var mockRepo = new Mock<IEmployeeService>();
            var addEmployeeList = GetEmployeeModelList();

            mockRepo.Setup(repo => repo.AddEmployeeRangeAsync(addEmployeeList)).ReturnsAsync(output);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.AddEmployeeRangeAsync(null);

            //// Assert
            Assert.Equal(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateEmployeeRange_ReturnOkResult()
        {
            // Arrange
            int output = 1;
            var mockRepo = new Mock<IEmployeeService>();
            var updateEmployeeList = GetEmployeeModelList();

            mockRepo.Setup(repo => repo.UpdateEmployeeRange(updateEmployeeList)).ReturnsAsync(output);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.UpdateEmployeeRange(updateEmployeeList);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateEmployeeRange_ReturnBadRequest()
        {
            // Arrange
            int output = 1;
            var mockRepo = new Mock<IEmployeeService>();
            var updateEmployeeList = GetEmployeeModelList();

            mockRepo.Setup(repo => repo.UpdateEmployeeRange(updateEmployeeList)).ReturnsAsync(output);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.UpdateEmployeeRange(null);

            //// Assert
            Assert.Equal(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task RemoveEmployeeByRange_ReturnOkResultWithSucess()
        {
            // Arrange
            int returnData = 1;

            var employeeList = GetEmployeeModelList();
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.RemoveEmployeeRange(employeeList)).ReturnsAsync(returnData);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.RemoveEmployeeByRange(employeeList);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }

        [Fact]
        public async Task RemoveEmployeeByRange_ReturnOkResultWithNotSucess()
        {
            // Arrange
            int returnData = 0;

            var employeeList = GetEmployeeModelList();
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.RemoveEmployeeRange(employeeList)).ReturnsAsync(returnData);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.RemoveEmployeeByRange(employeeList);

            //// Assert
            Assert.Equal(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(0, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
        }

        [Fact]
        public async Task RemoveEmployeeByRange_ReturnBadRequest()
        {
            // Arrange
            int returnData = 0;

            var employeeList = GetEmployeeModelList();
            var mockRepo = new Mock<IEmployeeService>();

            mockRepo.Setup(repo => repo.RemoveEmployeeRange(employeeList)).ReturnsAsync(returnData);

            var controller = new EmployeeController(mockRepo.Object);

            //// Act
            var result = await controller.RemoveEmployeeByRange(null);

            //// Assert
            Assert.Equal(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
            Assert.IsType<BadRequestResult>(result);
        }






        private List<EmployeeModel> GetEmployeeModelList()
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>()
            {
                new EmployeeModel{Id=1,Name="test1",EmailId="test1@gmail.com"},
                new EmployeeModel{Id=2,Name="test2",EmailId="test2@gmail.com"}
            };

            return employeeList;
        }

        private EmployeeModel GetEmployeeModelById(int emplyeeId)
        {
            var employee = GetEmployeeModelList().FirstOrDefault(x => x.Id == emplyeeId); ;
            return employee;
        }

        private IEnumerable<EmployeeModel> GetEmployeeModelUsingPredicate(int employeeId)
        {
            var productList = GetEmployeeModelList().Where(x => x.Id == employeeId);
            return productList;
        }

        private EmployeeModel GetEmployeeFirstOrDerfault(int employeeId)
        {
            var employee = GetEmployeeModelList().FirstOrDefault(x => x.Id == employeeId);
            return employee;
        }

        private EmployeeModel GetEmployeeSingleOrDefault(int employeeId)
        {
            var employee = GetEmployeeModelList().SingleOrDefault(x => x.Id == employeeId);
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
