using System.ComponentModel.DataAnnotations;

namespace FribergsCarRental.Data.Models
{
    public class Customer
    {

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }

    //public class Customer
    //{
    //    public int CustomerId { get; set; }

    //    [Required(ErrorMessage = "First name is required")]
    //    [StringLength(50, ErrorMessage = "First name must be at most 50 characters long")]
    //    public string FirstName { get; set; }

    //    [Required(ErrorMessage = "Last name is required")]
    //    [StringLength(50, ErrorMessage = "Last name must be at most 50 characters long")]
    //    public string LastName { get; set; }

    //    [Required(ErrorMessage = "Email address is required")]
    //    [EmailAddress(ErrorMessage = "Invalid email address")]
    //    public string Email { get; set; }

    //    [Required(ErrorMessage = "Password is required")]
    //    [StringLength(100, MinimumLength = 3, ErrorMessage = "Password must be at least 6 characters long")]
    //    public string Password { get; set; }
}

