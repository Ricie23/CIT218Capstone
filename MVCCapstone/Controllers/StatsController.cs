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

namespace MVCCapstone.Controllers
{
    [Authorize]
    public class StatsController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Stats
        [AllowAnonymous]
        public ActionResult Index()
        {
            var stats = db.Stats.Include(s => s.Games);
            return View(stats.ToList());
        }

        // GET: Stats/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stats stats = db.Stats.Find(id);
            if (stats == null)
            {
                return HttpNotFound();
            }
            return View(stats);
        }

        // GET: Stats/Create
        public ActionResult Create()
        {
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "Name");
            return View();
        }

        // POST: Stats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MyGamesID,HoursPlayed,IsBeaten,TrophiesEarned")] Stats stats)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Stats.Add(stats);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again. If problem persits contact the system administrator");
            }

            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "Name", stats.MyGamesID);
            return View(stats);
        }

        // GET: Stats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stats stats = db.Stats.Find(id);
            if (stats == null)
            {
                return HttpNotFound();
            }
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "Name", stats.MyGamesID);
            return View(stats);
        }

        // POST: Stats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MyGamesID,HoursPlayed,IsBeaten,TrophiesEarned")] Stats stats)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(stats).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again. If problem persits contact the system administrator");
            }
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "Name", stats.MyGamesID);
            return View(stats);
        }

        // GET: Stats/Delete/5
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
            Stats stats = db.Stats.Find(id);
            if (stats == null)
            {
                return HttpNotFound();
            }
            return View(stats);
        }

        // POST: Stats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Stats stats = db.Stats.Find(id);
                db.Stats.Remove(stats);
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
