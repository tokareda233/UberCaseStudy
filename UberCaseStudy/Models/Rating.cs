using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberCaseStudy.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Required]
        [Range(1,5)]
        public int Score { get; set; }
        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }
       
        public int RiderId { get; set; }
        public Ride? Ride { get; set; }


    }
}
