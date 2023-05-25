using System.ComponentModel.DataAnnotations;

namespace CarBookingManager.API.Models
{
    public class Customer
    {
        [Key]
        public string PersonalNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection <Reservation> Reservations { get; }
    }
}
