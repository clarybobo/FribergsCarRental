using System.ComponentModel.DataAnnotations;

namespace FribergsCarRental.Data.Models
{
    public class TheUser
    {

        public int TheUserId { get; set; }
        [Display(Name ="Förnamn")]
        public string FirstName { get; set; }

        [Display(Name ="Efternamn")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
