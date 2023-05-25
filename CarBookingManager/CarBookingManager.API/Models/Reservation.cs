using System.ComponentModel.DataAnnotations.Schema;

namespace CarBookingManager.API.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Car))]
        public string RegistrationNo { get; set; }
        public Car Car { get; set; }

        [ForeignKey(nameof(Customer))]
        public string PersonalNo { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateOfReservation { get; set; } = DateTime.UtcNow;
    }
}
