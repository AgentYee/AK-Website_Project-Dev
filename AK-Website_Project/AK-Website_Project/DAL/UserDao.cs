using AK_Website_Project.DAL.Interface;
using System;
using System.Collections.Generic;
using AK_Website_Project.Models.Entities;
using AK_Website_Project.Helpers;
using System.Linq;
using System.Data.Entity;

namespace AK_Website_Project.DAL
{
    public class UserDao : IUserDao
    {
        public bool CheckUserExistence(string username)
        {
            using (Entities ctx = new Entities())
            {
                foreach(User u in ctx.Users)
                {
                    if (u.Username == username)
                        return true;
                }
            }
            return false;
        }

        public bool CredentialsAreValid(string username, string password)
        {
            using (Entities ctx = new Entities())
            {
                bool result = false;

                string hashedPwd = EncryptionHelper.HashToSHA256(password);

                result = ctx.Users.Any(x => x.Username == username && x.Password == hashedPwd);

                return result;
            }
        }

        public bool DeleteUser(int userId)
        {
            int result = -1;
            using (Entities ctx = new Entities())
            {
                ctx.Users.Remove(ctx.Users.FirstOrDefault(x => x.UserId == userId));
                result = ctx.SaveChanges();
            }

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            using (Entities ctx = new Entities())
            {
                var list = ctx.Users;

                if (list != null)
                    return list.ToList();

                return new List<User>();
            }
        }

        public User GetUserById(int userId)
        {
            using (Entities ctx = new Entities())
            {
                User user = ctx.Users
                     .Include(x => x.Comments)
                     .FirstOrDefault(x => x.UserId == userId);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool RegisterUser(User user)
        {
            int result = -1;
            using (Entities ctx = new Entities())
            {
                user.Password = EncryptionHelper.HashToSHA256(user.Password);
                user.RoleId = 2; //2 is the role of a regular user, admin users will be created by the System admin
                ctx.Users.Add(user);
                result = ctx.SaveChanges();
            }

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}