using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.Entity;
using WebApplication2.Controllers;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            IEnumerable<Markers> markers = db.Markers;
            ViewBag.Markers = markers;
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Markers marker)
        {
            db.Markers.Add(marker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var marker = new Markers { id = id };
            db.Markers.Attach(marker);
            db.Markers.Remove(marker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Markers markers = db.Markers.Find(id);
            ViewBag.Marker = markers;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Markers markers)
        {
            db.Entry(markers).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}