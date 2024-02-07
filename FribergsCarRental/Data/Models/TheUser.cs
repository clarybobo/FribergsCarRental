using System.ComponentModel.DataAnnotations;

namespace FribergsCarRental.Data.Models
{
    public class TheUser
    {
       
        public int TheUserId { get; set; }
       
        public string FirstName { get; set; }

       
        public string LastName { get; set; }


        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }      
        public  bool IsAdmin { get; set; }
    }
}
