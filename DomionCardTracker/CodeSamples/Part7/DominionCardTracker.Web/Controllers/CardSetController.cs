using DominionCardTracker.DataLayer.Repositories;
using DominionCardTracker.Models.Tables;
using System.Web.Mvc;

namespace DominionCardTracker.Web.Controllers
{
    public class CardSetController : Controller
    {
        //
        // GET: /CardSet/
        private const string TempDataMessageKey = "Message";
        private CardSetRepository _repo = new CardSetRepository();

        public ActionResult Index()
        {
            var model = _repo.SelectAll();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CardSet();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CardSet newCardSet)
        {
            _repo.Insert(newCardSet);
            // TempData allows us to pass data to the next request
            TempData[TempDataMessageKey] = "Card Set Created!";
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
        public ActionResult Delete(CardSet cardSet)
        {
            _repo.Delete(cardSet.CardSetID);
            TempData[TempDataMessageKey] = "Card Set Deleted!";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = _repo.Select(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CardSet cardSet)
        {
            _repo.Update(cardSet);
            TempData[TempDataMessageKey] = "Card Set Saved!";
            return RedirectToAction("Index");
        }
    }
}
