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
    public class CoverArtsController : Controller
    {
        private GameContext db = new GameContext();

        // GET: CoverArts
        [AllowAnonymous]
        public ActionResult Index()
        {
            var coverArts = db.CoverArts.Include(c => c.MyGames);
            return View(coverArts.ToList());
        }

        // GET: CoverArts/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoverArt coverArt = db.CoverArts.Find(id);
            if (coverArt == null)
            {
                return HttpNotFound();
            }
            return View(coverArt);
        }

        // GET: CoverArts/Create
        public ActionResult Create()
        {
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "Name");
            return View();
        }

        // POST: CoverArts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MyGamesID,PhotoPath,AltText")] CoverArt coverArt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CoverArts.Add(coverArt);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again. If problem persits contact the system administrator");
            }

            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "Name", coverArt.MyGamesID);
            return View(coverArt);
        }

        // GET: CoverArts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoverArt coverArt = db.CoverArts.Find(id);
            if (coverArt == null)
            {
                return HttpNotFound();
            }
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "Name", coverArt.MyGamesID);
            return View(coverArt);
        }

        // POST: CoverArts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MyGamesID,PhotoPath,AltText")] CoverArt coverArt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(coverArt).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again. If problem persits contact the system administrator");
            }
            ViewBag.MyGamesID = new SelectList(db.Games, "ID", "Name", coverArt.MyGamesID);
            return View(coverArt);
        }

        // GET: CoverArts/Delete/5
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
            CoverArt coverArt = db.CoverArts.Find(id);
            if (coverArt == null)
            {
                return HttpNotFound();
            }
            return View(coverArt);
        }

        // POST: CoverArts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CoverArt coverArt = db.CoverArts.Find(id);
                db.CoverArts.Remove(coverArt);
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
