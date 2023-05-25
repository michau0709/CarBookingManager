using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Dtos.Responses;

namespace CarBookingManager.API.Services.CustomerService
{
    public interface ICustomerService
    {
        Task AddAsync(CustomerRequest customerRequest);
        Task UpdateAsync(CustomerRequest customerRequest);
        Task DeleteAsync(string personalNo);
        Task<IEnumerable<CustomerResponse>> GetAllAsync();
    }
}