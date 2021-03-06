﻿using System.ComponentModel.DataAnnotations;

namespace AK_Website_Project.Models.ViewModels.User
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        [MinLength(4)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [MinLength(8, ErrorMessage = "Minimum length of 8")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}