using System.ComponentModel.DataAnnotations;

namespace WEBSITESTEFANKEZDI.Models
{
    public class SignupViewModel
    {
        [Key]
        public Guid AccountId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
