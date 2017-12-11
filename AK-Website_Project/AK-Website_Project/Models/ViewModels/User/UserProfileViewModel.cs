using System.ComponentModel.DataAnnotations;

namespace AK_Website_Project.Models.ViewModels.User
{
    public class UserProfileViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [Editable(false)]
        public string Username { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Minimum length of 8")]
        public string Password { get; set; }
        public string Description { get; set; }
        [Editable(false)]
        public double Rating { get; set; }
        [Editable(false)]
        public int Stars { get; set; }
    }
}