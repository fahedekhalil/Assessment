using System.ComponentModel.DataAnnotations;

namespace CustomerOrderServiceAPI.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Address is required!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}