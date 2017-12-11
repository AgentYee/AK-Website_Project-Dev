using AK_Website_Project.DAL;
using AK_Website_Project.Models.ViewModels.User;
using AK_Website_Project.Repository;
using AK_Website_Project.Repository.Interface;
using System;
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

        public ActionResult Account()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Index", "Home");


            return View();
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