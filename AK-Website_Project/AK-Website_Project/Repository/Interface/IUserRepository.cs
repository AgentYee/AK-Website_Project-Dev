using AK_Website_Project.Models.Entities;
using AK_Website_Project.Models.ViewModels.User;
using System.Collections.Generic;

namespace AK_Website_Project.Repository.Interface
{
    public interface IUserRepository
    {
        //CRUD FUNCTIONS
        bool RegisterUser(UserRegisterViewModel user);
        bool DeleteUser(int userId);
        UserViewModel GetUserById(int userId);
        List<UserViewModel> GetAllUsers();
        bool CheckUserExistence(string username);
        bool CredentialsAreValid(string username, string password);
    }
}
