using System.ComponentModel.DataAnnotations;

namespace CoffeeShopWebsite.Models
{
    public enum UserRole
    {
        Customer = 0,
        Staff = 1,
        Admin = 2
    }

    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public UserRole Role { get; set; }
    }
}
