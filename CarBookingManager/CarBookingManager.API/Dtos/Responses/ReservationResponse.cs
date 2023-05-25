using CarBookingManager.API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBookingManager.API.Dtos.Responses
{
    public class ReservationResponse
    {
        public string RegistrationNo { get; set; }
        public string PersonalNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateOfReservation { get; set; } = DateTime.UtcNow;
    }
}
