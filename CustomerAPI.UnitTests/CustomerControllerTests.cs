using CustomerAPI.Controllers;
using CustomerAPI.Interface;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace CustomerAPI.UnitTests
{
    public class CustomerControllerTests
    {

        private readonly ICustomerRepository _customerRepository;
        public CustomerControllerTests()
        {
            _customerRepository = Substitute.For<ICustomerRepository>();

        }

        [Fact(DisplayName = "get return customer all customer")]
        public void GetCustomers_ReturnsOkResultWithListOfCustomers()
        {
            // Arrange
            _customerRepository.GetCusotmers().Returns(new List<Customer>
                {
                    new Customer { Id = new Guid("01234567-89ab-cdef-0123-456789abcdef"), FirstName = "sem", LastName = "jain",Age=30,Address="denhaag" }
                });

            var controller = new CustomerController(_customerRepository);
            // Act
            var result = controller.GetCustomers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var customer = Assert.IsType<List<Customer>>(okResult.Value);
            Assert.Equal("sem", customer[0].FirstName);
            Assert.Equal("jain", customer[0].LastName);

        }
        [Fact(DisplayName = "get customer details by id")]
        public async Task GetCustomersById_ReturnsOkResult()
        {
            // Arrange
            _customerRepository.GetCusotmerById(new Guid("01234567-89ab-cdef-0123-456789abcdef")).Returns(new Customer
            {
                Id = new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                FirstName = "sem",
                LastName = "jain",
                Age = 30,
                Address = "denhaag"
            });

            var controller = new CustomerController(_customerRepository);
            // Act
            var result = await controller.GetCustomersById(new Guid("01234567-89ab-cdef-0123-456789abcdef"));

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var customer = Assert.IsType<Customer>(okResult.Value);
            Assert.Equal("sem", customer.FirstName);
            Assert.Equal("jain", customer.LastName);

        }


        [Fact(DisplayName = "AddCustomer_ReturnsOkResultWithNewCustomer")]
        public async Task AddCustomer_ReturnsOkResultWithNewCustomer()
        {
            // Arrange
            var cust = new Customer { Id = new Guid("01234567-89ab-cdef-0123-456789abcdef"), FirstName = "sem", LastName = "jain", Age = 30, Address = "denhaag" };
            _customerRepository.AddCustomer(cust).Returns(new Customer
            {
                Id = new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                FirstName = "sem",
                LastName = "jain",
                Age = 30,
                Address = "denhaag"
            });
            
            var controller = new CustomerController(_customerRepository);
            // Act
            var result = await controller.AddCutomer(cust);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var customer = Assert.IsType<Customer>(okResult.Value);
            Assert.Equal("sem", customer.FirstName);
            Assert.Equal("jain", customer.LastName);
            Assert.Equal(30, customer.Age);

        }

        [Fact(DisplayName ="update custoer detail by id")]
        public async Task UpdateCustomer_ReturnsOkResult()
        {
            // Arrange
            var cust = new Customer { Id = new Guid("01234567-89ab-cdef-0123-456789abcdef"), FirstName = "sem", LastName = "jain", Age = 30, Address = "denhaag" };
            _customerRepository.UpdateCustomer(cust.Id, cust).Returns(new Customer
            {
                Id = new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                FirstName = "sandeep",
                LastName = "jain",
                Age = 30,
                Address = "denhaag"
            });

            var controller = new CustomerController(_customerRepository);
            // Act
            var result = await controller.UpdateCutomer(cust);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var customer = Assert.IsType<Customer>(okResult.Value);
            Assert.Equal("sandeep", customer.FirstName);
            Assert.Equal("jain", customer.LastName);
            Assert.Equal(30, customer.Age);
        }

        [Fact(DisplayName ="Delete customer details by id")]
        public async Task DeleteCustomer_ReturnsOkResult()
        {
            // Arrange           
            _customerRepository.DeleteCustomer(new Guid("01234567-89ab-cdef-0123-456789abcdef")).Returns(new Customer
            {
                Id = new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                FirstName = "sem",
                LastName = "jain",
                Age = 30,
                Address = "denhaag"
            });
            var controller = new CustomerController(_customerRepository);
            // Act
            var result = await controller.DeleteCutomer(new Guid("01234567-89ab-cdef-0123-456789abcdef"));
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var customer = Assert.IsType<Customer>(okResult.Value);
            Assert.Equal("sem", customer.FirstName);
            Assert.Equal("jain", customer.LastName);
            Assert.Equal(30, customer.Age);
        }
    }

}
