using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberCaseStudy.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]
        public string Color { get; set; }

       
        public int DriverId { get; set; }
        public User ?Driver { get; set; }

    }
}
