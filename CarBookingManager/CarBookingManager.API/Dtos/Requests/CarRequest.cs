using CarBookingManager.API.Models.Enums;

namespace CarBookingManager.API.Dtos.Requests
{
    public class CarRequest
    {
        public string RegistrationNo { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public FuelType Fuel { get; set; }
        public double Power { get; set; }
    }
}
