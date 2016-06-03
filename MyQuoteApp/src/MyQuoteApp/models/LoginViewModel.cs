using System.ComponentModel.DataAnnotations;

namespace MyQuoteApp.models
{
    public class LoginViewModel
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName must be required.!")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password must be required.!")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
