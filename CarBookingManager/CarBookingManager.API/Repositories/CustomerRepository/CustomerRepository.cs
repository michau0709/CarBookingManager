using CarBookingManager.API.Data;
using CarBookingManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBookingManager.API.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task AddAsync(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
             _dataContext.Customers.Remove(customer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Customer?> GetAsync(string personalNo)
        {
            return await _dataContext.Customers
                .AsNoTracking()
                .Include(c => c.Reservations)
                .FirstOrDefaultAsync(c => c.PersonalNo == personalNo);

        }

        public async Task<IEnumerable<Customer>?> GetAllAsync()
        {
            return await _dataContext.Customers
                .Include(c => c.Reservations)
                .ThenInclude(r=>r.Car)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
             _dataContext.Customers.Update(customer);
            await _dataContext.SaveChangesAsync();
        }
    }
}
