using System.ComponentModel.DataAnnotations;

namespace UberCaseStudy.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Role { get; set; }
        public Vehicle ?Vehicle { get; set; }
        public ICollection<Ride> ?RidesDriver { get; set; }
        public ICollection<Ride>? RidesRiders { get; set; }
    }
}
