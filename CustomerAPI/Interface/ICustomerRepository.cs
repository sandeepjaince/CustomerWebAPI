using CustomerAPI.Models;

namespace CustomerAPI.Interface
{
    public interface ICustomerRepository
    {

        Task<IEnumerable<Customer>> GetCusotmers();
         Task<Customer?> GetCusotmerById(Guid id);

        Task<Customer?> AddCustomer(Customer cust);

        Task<Customer?> UpdateCustomer(Guid id, Customer cust);

        Task<Customer?> DeleteCustomer(Guid id);
    }
}
