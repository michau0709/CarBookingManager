using CarBookingManager.API.Models;
namespace CarBookingManager.API.Repositories.CarRepository
{
    public interface ICarRepository
    {
        Task AddAsync(Car car);
        Task<Car?> GetAsync(string registrationNo);
    }
}