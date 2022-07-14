using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class User
    {
        public Employee Employee { get; set; }
        [Key]
        [ForeignKey("Employee")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email Can't Empty, Try Again !")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Can't Empty, Try Again !")]
        [StringLength(25)]
        [MinLength(6, ErrorMessage = "Minimum Password Character is 6")]
        public string Password { get; set; }
    }
}
