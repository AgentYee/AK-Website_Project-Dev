using AK_Website_Project.Models.Entities;
using System.Collections.Generic;

namespace AK_Website_Project.DAL.Interface
{
    public interface IUserDao
    {
        //CRUD FUNCTIONS
        bool RegisterUser(User user);
        bool DeleteUser(int userId);
        User GetUserById(int userId);
        List<User> GetAllUsers();
        bool SaveUserChanges(User user);

        //OTHER
        bool CheckUserExistence(string username);
        bool CredentialsAreValid(string username, string password);
        int GetUserIdByUsername(string username);
    }
}
