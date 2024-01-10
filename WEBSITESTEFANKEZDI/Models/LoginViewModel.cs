using System.ComponentModel;

namespace WEBSITESTEFANKEZDI.Models
{
    public class LoginViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Username:")]
        public string UserName { get; set; }

        [DisplayName("Password:")]
        public string Password { get; set; }
    }
}
