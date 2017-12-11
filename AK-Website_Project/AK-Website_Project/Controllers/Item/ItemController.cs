using AK_Website_Project.DAL;
using AK_Website_Project.Models.Entities;
using AK_Website_Project.Models.ViewModels.Item;
using AK_Website_Project.Repository;
using AK_Website_Project.Repository.Interface;
using System;
using System.Web.Mvc;

namespace AK_Website_Project.Controllers.Item
{
    public class ItemController : Controller
    {
        private readonly IItemRepository repo;
        private readonly ICommentRepository repo2;

        public ItemController(IItemRepository _repo, ICommentRepository _repo2)
        {
            repo = _repo;
            repo2 = _repo2;
        }

        public ItemController()
        {
            repo = new ItemRepository(new ItemDao());
            repo2 = new CommentRepository(new CommentDao());
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
            itemVM.PicturePath = item.Picture == null ? "" : item.Picture.Path;


            return View(itemVM);
        }

        public ActionResult PostComment(string ItemId, string commentContent)
        {
            Comment comment = new Comment();
            comment.Content = commentContent;
            comment.CreatorId = Convert.ToInt32(Session["UserId"]);
            comment.AttachedToItemId = Convert.ToInt32(ItemId);
            repo2.PostComment(comment);

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}
