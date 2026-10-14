using System.ComponentModel.DataAnnotations;

namespace UberCaseStudy.DTO.Vehicle
{
    public class CreateVehicleDTO
    {
       
        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]
        public string Color { get; set; }


        public int DriverId { get; set; }
    }
}
