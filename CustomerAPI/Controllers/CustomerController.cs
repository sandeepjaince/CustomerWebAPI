using CustomerAPI.Interface;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customer = await _customerRepository.GetCusotmers();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(customer);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCustomersById([FromRoute] Guid id)
        {

            try
            {
                var customer = await _customerRepository.GetCusotmerById(id);

                return customer != null ? Ok(customer) : NotFound(new ProblemDetails { Title = "Customer detail not found for Customer ID: " + id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddCutomer(Customer objcust)
        {
            try
            {
                var customer = await _customerRepository.AddCustomer(objcust);
                return customer != null ? Ok(customer) : NotFound(new ProblemDetails { Title = "Issue occur during insert new customer details: " });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }
        [HttpPut]
        public async Task<IActionResult> UpdateCutomer(Customer objcust)
        {

            try
            {
                var customer = await _customerRepository.UpdateCustomer(objcust.Id, objcust);
                return customer != null ? Ok(customer) : NotFound(new ProblemDetails { Title = "Customer details not found for Customer Id: " + objcust.Id });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCutomer([FromRoute] Guid id)
        {
            try
            {
                var customer = await _customerRepository.DeleteCustomer(id);
                return customer != null ? Ok(customer) : NotFound(new ProblemDetails { Title = "Customer details not found for Customer Id: " + id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
