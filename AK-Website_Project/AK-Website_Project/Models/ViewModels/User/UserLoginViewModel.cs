using System.ComponentModel.DataAnnotations;

namespace AK_Website_Project.Models.ViewModels.User
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username;
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password;
    }
}