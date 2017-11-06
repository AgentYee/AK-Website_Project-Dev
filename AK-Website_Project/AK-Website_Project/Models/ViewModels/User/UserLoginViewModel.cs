using System.ComponentModel.DataAnnotations;

namespace AK_Website_Project.Models.ViewModels.User
{
    public class UserLoginViewModel
    {
        [Required]
        public string Username;
        [Required]
        public string Password;
    }
}