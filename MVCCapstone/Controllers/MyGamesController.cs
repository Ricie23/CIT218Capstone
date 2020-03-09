using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCapstone.DAL;
using MVCCapstone.Models;
using PagedList;


namespace MVCCapstone.Controllers
{
    [Authorize]
    public class MyGamesController : Controller
    {
        private GameContext db = new GameContext();

        // GET: MyGames
        [AllowAnonymous]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.GenreSortParm = sortOrder == "Genre" ? "genre_desc" : "Genre";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.currentFilter = searchString;

            var games = from g in db.Games
                        select g;
            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(g => g.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    games = games.OrderByDescending(g => g.Name);
                    break;
                case "Genre":
                    games = games.OrderBy(g => g.Genre);
                    break;
                case "genre_desc":
                    games = games.OrderByDescending(g => g.Genre);
                    break;
                default:
                    games = games.OrderBy(g => g.Name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(games.ToPagedList(pageNumber, pageSize));
        }
        [AllowAnonymous]
        public ActionResult Display()
        {
            return View(db.Games.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDisplay([Bind(Include = "ID,Name,Genre, Price")] MyGames myGames)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myGames).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Display");
            }
            return View(myGames);
        }

        //GET: Student/Edit/5
        public ActionResult EditDisplay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyGames myGames = db.Games.Find(id);
            if (myGames == null)
            {
                return HttpNotFound();
            }
            return View(myGames);
        }
        // GET: MyGames/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyGames myGames = db.Games.Find(id);
            if (myGames == null)
            {
                return HttpNotFound();
            }
            return View(myGames);
        }

        // GET: MyGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Genre,Price")] MyGames myGames)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Games.Add(myGames);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again. If problem persits contact the system administrator");
            }

            return View(myGames);
        }

        // GET: MyGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyGames myGames = db.Games.Find(id);
            if (myGames == null)
            {
                return HttpNotFound();
            }
            return View(myGames);
        }

        // POST: MyGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Genre,Price")] MyGames myGames)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(myGames).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again. If problem persits contact the system administrator");
            }
            return View(myGames);
        }

        // GET: MyGames/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, if the problem persists please contact the system administrator.";
            }
            MyGames myGames = db.Games.Find(id);
            if (myGames == null)
            {
                return HttpNotFound();
            }
            return View(myGames);
        }

        // POST: MyGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                MyGames myGames = db.Games.Find(id);
                db.Games.Remove(myGames);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
