using NUnit.Framework;
using Moq;
using EMS.Services;
using EMS.Services.Interfaces;
using EMS.Data.Repositories;
using EMS.Data.Models;
using EMS.Data.DTOs;

namespace EMS.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _mockRepository;
        private IEmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_mockRepository.Object);
        }

        [Test]
        public async Task GetEmployeeById_WithValidId_ReturnsEmployee()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee
            {
                Id = employeeId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john@company.com",
                DepartmentId = 1,
                RoleId = 4,
                IsActive = true
            };

            _mockRepository
                .Setup(r => r.GetByIdAsync(employeeId))
                .ReturnsAsync(employee);

            // Act
            var result = await _employeeService.GetEmployeeByIdAsync(employeeId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("john@company.com", result.Email);
        }

        [Test]
        public async Task CreateEmployee_WithValidData_CreatesEmployee()
        {
            // Arrange
            var createDto = new CreateEmployeeDto
            {
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane@company.com",
                PhoneNumber = "1234567890",
                DepartmentId = 2,
                RoleId = 4,
                Salary = 50000,
                DateOfBirth = new DateTime(1990, 1, 1),
                HireDate = DateTime.UtcNow
            };

            // Act & Assert
            Assert.DoesNotThrowAsync(async () =>
                await _employeeService.CreateEmployeeAsync(createDto));
        }
    }
}
