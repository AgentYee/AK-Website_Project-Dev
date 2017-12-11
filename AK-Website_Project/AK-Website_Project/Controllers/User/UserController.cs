using AK_Website_Project.DAL;
using AK_Website_Project.Helpers;
using AK_Website_Project.Models.Entities;
using AK_Website_Project.Models.ViewModels.User;
using AK_Website_Project.Repository;
using AK_Website_Project.Repository.Interface;
using System;
using System.Net;
using System.Web.Mvc;

namespace AK_Website_Project.Controllers.User
{
    public class UserController : Controller
    {
        private readonly IUserRepository repo;

        public UserController(IUserRepository _repo)
        {
            repo = _repo;
        }

        public UserController()
        {
            repo = new UserRepository(new UserDao());
        }

        [HttpGet]
        public ActionResult Account(int id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "User");
            if(Convert.ToInt32(Session["UserId"]) != id)
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Bad boy");

            UserProfileViewModel user = repo.GetUserProfileByUserId(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Account(UserProfileViewModel profile)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "User");

            if (profile.UserId == Convert.ToInt32(Session["UserId"]) && profile.Username == Session["Username"].ToString())
            {
                if (ModelState.IsValid)
                {
                    Models.Entities.User user = repo.GetRawUserById(Convert.ToInt32(Session["UserId"]));
                    user.Description = profile.Description;

                    if (user.Password != profile.Password)
                    {
                        user.Password = EncryptionHelper.HashToSHA256(profile.Password);
                    }

                    repo.SaveUserChanges(user);
                }
                return View(profile);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Bad boy");
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Username"] == null)
                return View(new UserLoginViewModel());

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            if (Session["Username"] == null)
                return View(new UserRegisterViewModel());

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLoginViewModel user)
        {
            if (Session["Username"] == null)
            {
                if (ModelState.IsValid)
                {
                    if (repo.CredentialsAreValid(user.Username, user.Password))
                    {
                        Session["Username"] = user.Username;
                        Session["UserId"] = repo.GetUserIdByUsername(user.Username);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("LoginError", "Invalid username/password combination");
                        return View(user);
                    }
                }
                else
                {
                    return View(user);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(UserRegisterViewModel user)
        {
            if (Session["Username"] == null)
            {
                if (ModelState.IsValid)
                {
                    if (!repo.CheckUserExistence(user.Username))
                    {
                        if (repo.RegisterUser(user))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("SignUpError", "An error has occured");
                            return View(user);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("SignUpError", "Username is already taken");
                        return View(user);
                    }
                }
                else
                {
                    return View(user);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session["Username"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}