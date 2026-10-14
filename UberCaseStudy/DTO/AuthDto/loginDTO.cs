using System.ComponentModel.DataAnnotations;

namespace UberCaseStudy.DTO.AuthDto
{
    public class loginDTO
    {

        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
