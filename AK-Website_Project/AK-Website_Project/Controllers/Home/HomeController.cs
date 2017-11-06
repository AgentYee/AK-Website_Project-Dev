using AK_Website_Project.Models.ViewModels.Home;
using System.Web.Mvc;

namespace AK_Website_Project.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View(new HomeViewModel());
        }
    }
}