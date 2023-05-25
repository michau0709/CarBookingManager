using CarBookingManager.API.Data;
using CarBookingManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBookingManager.API.Repositories.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _dataContext;
        public CarRepository(DataContext dataContext)
        {
             _dataContext = dataContext;
        }

        public async Task AddAsync(Car car)
        {
            _dataContext.Cars.Add(car);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Car?> GetAsync(string registrationNo)
        {
            return await _dataContext.Cars.FirstOrDefaultAsync(car=> car.RegistrationNo==registrationNo);
        
       
        }
    }
}
