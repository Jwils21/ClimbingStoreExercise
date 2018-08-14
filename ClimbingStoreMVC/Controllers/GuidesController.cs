using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClimbingStoreMVC.Models;

namespace ClimbingStoreMVC.Controllers
{
    public class GuidesController : Controller
    {
        private ClimbingStoreMVCContext db = new ClimbingStoreMVCContext();

        // GET: Guides
        public ActionResult Index()
        {
            var guides = db.Guides.Include(g => g.Party);
            return View(guides.ToList());
        }

        // GET: Guides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guide guide = db.Guides.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        // GET: Guides/Create
        public ActionResult Create()
        {
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "PartyName");
            return View();
        }

        // POST: Guides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,YrsExp,PartyId")] Guide guide)
        {
            if (ModelState.IsValid)
            {
                db.Guides.Add(guide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartyId = new SelectList(db.Parties, "Id", "PartyName", guide.PartyId);
            return View(guide);
        }

        // GET: Guides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guide guide = db.Guides.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "PartyName", guide.PartyId);
            return View(guide);
        }

        // POST: Guides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,YrsExp,PartyId")] Guide guide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "PartyName", guide.PartyId);
            return View(guide);
        }

        // GET: Guides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guide guide = db.Guides.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        // POST: Guides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guide guide = db.Guides.Find(id);
            db.Guides.Remove(guide);
            db.SaveChanges();
            return RedirectToAction("Index");
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
