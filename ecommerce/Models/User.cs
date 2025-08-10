using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public override string Email { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
