using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MarkersController : Controller
    {
        private WebApplication2Context db = new WebApplication2Context();

        // GET: Markers
        public ActionResult Index()
        {
            return View(db.Markers.ToList());
        }

        // GET: Markers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markers markers = db.Markers.Find(id);
            if (markers == null)
            {
                return HttpNotFound();
            }
            return View(markers);
        }

        // GET: Markers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Markers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,x,y")] Markers markers)
        {
            if (ModelState.IsValid)
            {
                db.Markers.Add(markers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(markers);
        }

        // GET: Markers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markers markers = db.Markers.Find(id);
            if (markers == null)
            {
                return HttpNotFound();
            }
            return View(markers);
        }

        // POST: Markers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,x,y")] Markers markers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(markers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(markers);
        }

        // GET: Markers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markers markers = db.Markers.Find(id);
            if (markers == null)
            {
                return HttpNotFound();
            }
            return View(markers);
        }

        // POST: Markers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Markers markers = db.Markers.Find(id);
            db.Markers.Remove(markers);
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
