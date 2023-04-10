using CustomerAPI.Data;
using CustomerAPI.Interface;
using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerDBContext _customerDataConect;
        public CustomerRepository(CustomerDBContext customerDataConect)
        {
            _customerDataConect = customerDataConect;
        }
        public async Task<Customer?> AddCustomer(Customer cust)
        {
            
            cust.Id =  new Guid();
            var custobj = await _customerDataConect.Customers.AddAsync(cust);
            await _customerDataConect.SaveChangesAsync();
            return custobj.Entity;
        }
        public async Task<Customer?> DeleteCustomer(Guid id)
        {
            var custobj = await _customerDataConect.Customers.FindAsync(id);
            if (custobj != null)
            {
                _customerDataConect.Customers.Remove(custobj);
                await _customerDataConect.SaveChangesAsync();
            }
            return custobj;
        }
        public async Task<Customer?> GetCusotmerById(Guid id)
        {
            return await _customerDataConect.Customers.FindAsync(id);

        }
        public async Task<IEnumerable<Customer>> GetCusotmers()
        {

            return await _customerDataConect.Customers.ToListAsync();
        }
        public async Task<Customer?> UpdateCustomer(Guid id, Customer cust)
        {
            var custobj = await _customerDataConect.Customers.FindAsync(id);
            if (custobj != null)
            {
                custobj.FirstName = cust.FirstName;
                custobj.LastName = cust.LastName;
                custobj.Age = cust.Age;
                _customerDataConect.Customers.Update(custobj);
                await _customerDataConect.SaveChangesAsync();
            }
            return custobj;
        }
    }
}
