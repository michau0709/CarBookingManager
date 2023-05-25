using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Dtos.Responses;

namespace CarBookingManager.API.Services.CarService
{
    public interface ICarService
    {
        Task AddAsync(CarRequest car);
        Task<IEnumerable<CarReservationResponse>> GetAllAssignedAsync();
    }
}