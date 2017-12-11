using AK_Website_Project.DAL.Interface;
using AK_Website_Project.Models.Entities;
using AK_Website_Project.Models.ViewModels.Comment;
using AK_Website_Project.Models.ViewModels.User;
using AK_Website_Project.Repository.Interface;
using System.Collections.Generic;

namespace AK_Website_Project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDao dao;

        public UserRepository(IUserDao dao)
        {
            this.dao = dao;
        }

        public bool DeleteUser(int userId)
        {
            bool result = dao.DeleteUser(userId);
            return result;
        }

        public bool RegisterUser(UserRegisterViewModel userViewModel)
        {
            //map viewmodel to entity
            User user = new User();
            user.Username = userViewModel.Username;
            user.Password = userViewModel.Password;
            user.Description = "";
            user.IsDisabled = false;

            bool result = dao.RegisterUser(user);

            return result;
        }

        public bool CheckUserExistence(string username)
        {
            return dao.CheckUserExistence(username);
        }

        public bool CredentialsAreValid(string username, string password)
        {
            return dao.CredentialsAreValid(username, password);
        }

        public List<UserViewModel> GetAllUsers()
        {
            List<User> users = dao.GetAllUsers();
            List<UserViewModel> usersViewModel = new List<UserViewModel>();

            users.ForEach(x => usersViewModel.Add(ToViewModel(x)));

            return usersViewModel;
        }

        public UserViewModel GetUserById(int userId)
        {
            User user = dao.GetUserById(userId);

            return user != null ? ToViewModel(user) : null;
        }

        private UserViewModel ToViewModel(User user)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.UserId = user.UserId;
            userViewModel.Username = user.Username;
            userViewModel.Description = user.Description;


            List<CommentViewModel> commentsViewModel = new List<CommentViewModel>();

            if (user.Comments != null)
            {
                foreach (Comment comment in user.Comments)
                {
                    CommentViewModel commentViewModel = new CommentViewModel();
                    commentViewModel.CommentId = comment.CommentId;
                    commentViewModel.Content = comment.Content;
                    commentViewModel.AttachedToItemId = comment.AttachedToItemId;
                    commentViewModel.CreatorId = comment.CreatorId;
                    commentViewModel.Rating = (float)comment.Rating;
                    if (comment.RateCount == null)
                        commentViewModel.RateCount = 0;
                    else
                        commentViewModel.RateCount = (int)comment.RateCount;

                    commentsViewModel.Add(commentViewModel);
                }
            }

            userViewModel.Comments = commentsViewModel;

            return userViewModel;
        }

        public int GetUserIdByUsername(string username)
        {
            return dao.GetUserIdByUsername(username);
        }

        public UserProfileViewModel GetUserProfileByUserId(int userId)
        {
            User user = dao.GetUserById(userId);
            if(user != null)
            {
                UserProfileViewModel viewModel = new UserProfileViewModel();
                viewModel.UserId = user.UserId;
                viewModel.Username = user.Username;
                viewModel.Password = user.Password;
                viewModel.Description = user.Description;

                return viewModel;
            }
            return null;
        }

        public bool SaveUserChanges(User user)
        {
            return dao.SaveUserChanges(user);
        }

        public User GetRawUserById(int userId)
        {
            return dao.GetUserById(userId);
        }
    }
}