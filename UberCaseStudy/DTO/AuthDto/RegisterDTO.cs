using System.ComponentModel.DataAnnotations;

namespace UberCaseStudy.DTO.AuthDto
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
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
    }
}
