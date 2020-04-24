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
    public class TrophiesController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Trophies
        [AllowAnonymous]
        public ActionResult Index()
        {
            var trophies = db.Trophies.Include(t => t.Games);
            return View(trophies.ToList());
        }
        [AllowAnonymous]
        // GET: Trophies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trophies trophies = db.Trophies.Find(id);
            if (trophies == null)
            {
                return HttpNotFound();
            }
            return View(trophies);
        }

        // GET: Trophies/Create
        public ActionResult Create()
        {
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "ID");
            return View();
        }

        // POST: Trophies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MyGamesID,Name,Description,Type")] Trophies trophies)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Trophies.Add(trophies);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again. If problem persits contact the system administrator");
            }
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "ID", trophies.MyGamesID);
            return View(trophies);
        }

        // GET: Trophies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trophies trophies = db.Trophies.Find(id);
            if (trophies == null)
            {
                return HttpNotFound();
            }
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "ID", trophies.MyGamesID);
            return View(trophies);
        }

        // POST: Trophies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MyGamesID,Name,Description,Type")] Trophies trophies)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(trophies).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again. If problem persits contact the system administrator");
            }
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "ID", trophies.MyGamesID);
            return View(trophies);
        }

        // GET: Trophies/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trophies trophies = db.Trophies.Find(id);
            if (trophies == null)
            {
                return HttpNotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, if the problem persists please contact the system administrator.";
            }
            return View(trophies);
        }

        // POST: Trophies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Trophies trophies = db.Trophies.Find(id);
                db.Trophies.Remove(trophies);
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
