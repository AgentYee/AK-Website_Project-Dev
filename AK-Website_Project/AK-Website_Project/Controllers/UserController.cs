using AK_Website_Project.Models.ViewModels.User;
using System.Web.Mvc;

namespace AK_Website_Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Account()
        {
            if (Session["Username"] == null)
                return View();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Username"] == null)
                return View();

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
        public ActionResult Login(UserLoginViewModel userViewModel)
        {
            if (Session["Username"] == null)
                return View(userViewModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(UserRegisterViewModel userViewModel)
        {
            if (Session["Username"] == null)
            {
                if(ModelState.IsValid)
                {
                }
                return View(userViewModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}