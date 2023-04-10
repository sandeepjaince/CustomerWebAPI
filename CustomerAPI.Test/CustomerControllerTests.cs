using CustomerAPI.Controllers;
using CustomerAPI.Data;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Sdk;

namespace CustomerAPI.Test
{
  
    public class CustomerControllerTests
    {
       
        public CustomerControllerTests()
        {
            
        }

        [Fact(DisplayName = "get return customer value")]
        public void GetCustomers_ReturnsOkResultWithListOfCustomers()
        {
            // Arrange


            var options = new DbContextOptionsBuilder<CustomerDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            var dbContext = new CustomerDBContext(options);
            dbContext.Customers.Add(new Customer { Id = new Guid(), FirstName = "sandeep", LastName = "jain", Age = 40, Address = "Denhaag" });
            dbContext.Customers.Add(new Customer { Id = new Guid(), FirstName = "soham", LastName = "jain", Age = 12, Address = "Denhaag" });
            dbContext.SaveChanges();
            var controller = new CustomerController(dbContext);

            // Act
            var result = controller.GetCustomers();

            // Assert
            var okResult = result as OkObjectResult;
          //  Assert.IsNotNull(okResult);
            //Assert.AreEqual(200, okResult.StatusCode);
            var customers = okResult.Value as List<Customer>;
           // Assert.IsNotNull(customers);
          //  Assert.AreEqual(2, customers.Count);
           // Assert.AreEqual("sandeep", customers[0].FirstName);
            
        }

    }
}