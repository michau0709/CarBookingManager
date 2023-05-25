using CarBookingManager.API.Models;

namespace CarBookingManager.API.Dtos.Responses
{
    public class CustomerResponse
    {
        public string PersonalNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IEnumerable<ReservationCustomerResponse> Reservations { get; set; }
    }
}
