using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominionCardTracker.DataLayer.Repositories;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.Web.Controllers
{
    public class ModifierTypeController : Controller
    {
        private const string TempDataMessageKey = "Message";
        private ModifierTypeRepository _repo = new ModifierTypeRepository();

        public ActionResult Index()
        {
            var model = _repo.SelectAll();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new ModifierType();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ModifierType newModifierType)
        {
            _repo.Insert(newModifierType);
            // TempData allows us to pass data to the next request
            TempData[TempDataMessageKey] = "Modifier Type Created!";
            return RedirectToAction("Index");
        }

        // we pass the route value id in the link
        // see App_Start/RouteConfig for why this works
        public ActionResult Delete(int id)
        {
            var model = _repo.Select(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(ModifierType ModifierType)
        {
            _repo.Delete(ModifierType.ModifierTypeID);
            TempData[TempDataMessageKey] = "Modifier Type Deleted!";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = _repo.Select(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ModifierType ModifierType)
        {
            _repo.Update(ModifierType);
            TempData[TempDataMessageKey] = "Modifier Type Saved!";
            return RedirectToAction("Index");
        }
    }
}
