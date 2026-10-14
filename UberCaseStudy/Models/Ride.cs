using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberCaseStudy.Models
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string PickUpLocation { get; set; }
        [Required]
        [MaxLength(150)]
        public string DropOfLocation { get; set; }
        [Required]
        [Range(20,5000)]
        public int Fare {  get; set; }
        [Required]
        public string Status { get; set; }

        [ForeignKey("Rider")]
        public int RiderUserId { get; set; }
        public User ?Rider { get; set; }
       
        public int DriverId { get; set; }
        public User ?Driver { get; set; }

        public Payment ?Payment { get; set; }

        public Rating ?Rating { get; set; }

    }
}
