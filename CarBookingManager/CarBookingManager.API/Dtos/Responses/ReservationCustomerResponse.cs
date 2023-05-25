namespace CarBookingManager.API.Dtos.Responses
{
    public class ReservationCustomerResponse
    {
        public string RegistrationNo { get; set; }
        public string CarModel { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateOfReservation { get; set; } = DateTime.UtcNow;
    }
}
