using CarBookingManager.API.Models;

namespace CarBookingManager.API.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        Task AddAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllAsync();
    }
}