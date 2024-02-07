using System.ComponentModel.DataAnnotations;

namespace FribergsCarRental.Data.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }      
        public  bool IsAdmin { get; set; }
    }
}
