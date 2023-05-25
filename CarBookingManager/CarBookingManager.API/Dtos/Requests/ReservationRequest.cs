namespace CarBookingManager.API.Dtos.Requests
{
    public class ReservationRequest
    {
        public string RegistrationNo { get; set; }
        public string CustomerPersonalNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
