using AK_Website_Project.DAL;
using AK_Website_Project.Models.ViewModels.Item;
using AK_Website_Project.Repository;
using AK_Website_Project.Repository.Interface;
using System.Web.Mvc;

namespace AK_Website_Project.Controllers.Item
{
    public class ItemController : Controller
    {
        private readonly IItemRepository repo;

        public ItemController(IItemRepository _repo)
        {
            repo = _repo;
        }

        public ItemController()
        {
            repo = new ItemRepository(new ItemDao());
        }

        // GET: Item
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            Models.Entities.Item item = repo.GetItem(id);

            ItemViewModel itemVM = new ItemViewModel();
            itemVM.ItemId = item.ItemId;
            itemVM.Name = item.Name;
            itemVM.QualityLevel = item.QualityLevel;
            itemVM.SubCategoryId = item.SubCategoryId;
            itemVM.Comments = item.Comments;
            itemVM.SubCategory = item.SubCategory;

            return View(itemVM);
        }
    }
}
