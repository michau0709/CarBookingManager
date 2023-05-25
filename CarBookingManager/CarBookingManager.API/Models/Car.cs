using CarBookingManager.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarBookingManager.API.Models
{
    public class Car
    {
        [Key]
        public string RegistrationNo { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public FuelType Fuel { get; set; }
        public double Power { get; set; }
  
    }
}
