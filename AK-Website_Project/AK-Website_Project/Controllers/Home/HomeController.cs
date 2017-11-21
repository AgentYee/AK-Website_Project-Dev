using AK_Website_Project.Models.Entities;
using AK_Website_Project.Models.ViewModels.Home;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Data.Entity;
using AK_Website_Project.Repository.Interface;
using AK_Website_Project.DAL;
using AK_Website_Project.Repository;

namespace AK_Website_Project.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository repo;

        public HomeController(ICategoryRepository _repo)
        {
            repo = _repo;
        }

        public HomeController()
        {
            repo = new CategoryRepository(new CategoryDao());
        }
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoadDataTable()
        {
            //jQuery DataTables Param
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //Find paging info
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //Find order columns info
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault()
                                    + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //find search columns info
            var itemName = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt16(start) : 0;
            int recordsTotal = 0;

            using (Entities dc = new Entities())
            {
                dc.Configuration.LazyLoadingEnabled = false;
                var v = (from a in dc.Items
                         .Include(x => x.QualityLevel)
                         .Include(x => x.SubCategory) select new { a.ItemId, a.Name, QualityName = a.QualityLevel.Name, SubCategoryName = a.SubCategory.Name });

                //SEARCHING...
                if (!string.IsNullOrEmpty(itemName))
                {
                    v = v.Where(a => a.Name.Contains(itemName));
                }

                //SORTING...
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    v = v.OrderBy(sortColumn + " " + sortColumnDir);
                }

                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data },
                    JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult RenderDropdowns()
        {
            var model = new HomeViewModel();
            model.Categories = repo.GetCategoryList();
            return PartialView("~/Views/Shared/_DropdownsPartial.cshtml", model);
        }
    }
}