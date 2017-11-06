using System.ComponentModel.DataAnnotations;

namespace AK_Website_Project.Models.ViewModels.User
{
    public class UserRegisterViewModel
    {
        [Required]
        [MinLength(4)]
        public string Username;
        [Required]
        [MinLength(8)]
        public string Password;
        [Required]
        [MinLength(8)]
        public string ConfirmPassword;
    }
}