using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string District {  get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public String Province { get; set; }
    }

}
