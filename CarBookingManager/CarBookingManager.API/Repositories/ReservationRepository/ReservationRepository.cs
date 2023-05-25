using CarBookingManager.API.Data;
using CarBookingManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBookingManager.API.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _dataContext;

        public ReservationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Reservation reservation)
        {
            _dataContext.Reservations.Add(reservation);
           await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _dataContext.Reservations
                .Include(r=>r.Car)
                .Include(r=>r.Customer)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
