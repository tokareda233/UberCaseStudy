using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace UberCaseStudy.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Range(20,10000)]
        public int Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string Status { get; set; }
      
        public int RiderId { get; set; }
        public Ride ?Ride {  get; set; }
    }
}
