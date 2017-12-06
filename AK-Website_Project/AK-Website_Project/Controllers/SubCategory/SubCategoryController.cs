using AK_Website_Project.DAL;
using AK_Website_Project.Models.Entities;
using AK_Website_Project.Models.ViewModels.SubCategory;
using AK_Website_Project.Repository;
using AK_Website_Project.Repository.Interface;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq.Dynamic;

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
            viewModel.Category = subCategory.Category;
            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoadDataTable(int id)
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
                         .Include(x => x.SubCategory)
                         .Where(x => x.SubCategoryId == id)
                         select new { a.ItemId, a.Name, QualityName = a.QualityLevel.Name });

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
    }
}
