using AK_Website_Project.Models.ViewModels.Comment;
using System.Collections.Generic;

namespace AK_Website_Project.Models.ViewModels.User
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public List<CommentViewModel> Comments;
    }
}