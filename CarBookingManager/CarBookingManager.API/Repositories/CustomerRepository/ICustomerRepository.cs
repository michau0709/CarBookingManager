using CarBookingManager.API.Models;

namespace CarBookingManager.API.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task<Customer?> GetAsync(string personalNo);
        Task UpdateAsync(Customer customer);
        Task<IEnumerable<Customer>?> GetAllAsync();
    }
}