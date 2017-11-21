using AK_Website_Project.DAL;
using AK_Website_Project.Models.ViewModels.SubCategory;
using AK_Website_Project.Repository;
using AK_Website_Project.Repository.Interface;
using System.Web.Mvc;

namespace AK_Website_Project.Controllers.SubCategory
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryRepository repo;

        public SubCategoryController(ISubCategoryRepository _repo)
        {
            repo = _repo;
        }

        public SubCategoryController()
        {
            repo = new SubCategoryRepository(new SubCategoryDao());
        }
        // GET: SubCategory/View/5
        public ActionResult View(int id)
        {
            var subCategory = repo.GetSubCategory(id);
            var viewModel = new SubCategoryViewModel();
            viewModel.SubCategoryId = subCategory.SubCategoryId;
            viewModel.Name = subCategory.Name;
            viewModel.Items = subCategory.Items;
            return View(viewModel);
        }
    }
}
