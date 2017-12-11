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
        public ActionResult Login(string username, string password)
        {
            if (Session["Username"] == null)
            {
                //TODO: Remove this
                if (!ModelState.IsValid)
                    return View(new UserLoginViewModel());

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return View(new UserLoginViewModel());

                if (repo.CredentialsAreValid(username, password))
                {
                    Session["Username"] = username;
                    return RedirectToAction("Index", "Home");
                }
                return View(new UserLoginViewModel());
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(UserRegisterViewModel user)
        {
            if (Session["Username"] == null)
            {
                if (!ModelState.IsValid)
                    return View(user);

                if (repo.RegisterUser(user))
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(new UserRegisterViewModel());
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