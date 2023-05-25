using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Dtos.Responses;

namespace CarBookingManager.API.Services.ReservationService
{
    public interface IReservationService
    {
        Task AddAsync(ReservationRequest reservationRequest);
        Task<IEnumerable<ReservationResponse>> GetAllAsync();
    }
}