using System.Web.Mvc;
using DominionCardTracker.DataLayer.Repositories;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.Web.Controllers
{
    public class CategoryController : Controller
    {
        private const string TempDataMessageKey = "Message";
        private CategoryRepository _repo = new CategoryRepository();

        public ActionResult Index()
        {
            var model = _repo.SelectAll();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new Category();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Category newCategory)
        {
            _repo.Insert(newCategory);
            
            TempData[TempDataMessageKey] = "Category Created!";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var model = _repo.Select(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            _repo.Delete(category.CategoryID);
            TempData[TempDataMessageKey] = "Category Deleted!";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = _repo.Select(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            _repo.Update(category);
            TempData[TempDataMessageKey] = "Category Saved!";
            return RedirectToAction("Index");
        }
    }
}
