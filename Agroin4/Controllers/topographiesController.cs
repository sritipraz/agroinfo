using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agroin4.Models;

namespace Agroin4.Controllers
{
    public class topographiesController : Controller
    {
        private webAppModel db = new webAppModel();

        // GET: topographies
        public ActionResult Index()
        {
            return View(db.topographys.ToList());
        }

        // GET: topographies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            topography topography = db.topographys.Find(id);
            if (topography == null)
            {
                return HttpNotFound();
            }
            return View(topography);
        }

        // GET: topographies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: topographies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,topography_name")] topography topography)
        {
            if (ModelState.IsValid)
            {
                db.topographys.Add(topography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topography);
        }

        // GET: topographies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            topography topography = db.topographys.Find(id);
            if (topography == null)
            {
                return HttpNotFound();
            }
            return View(topography);
        }

        // POST: topographies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,topography_name")] topography topography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topography);
        }

        // GET: topographies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            topography topography = db.topographys.Find(id);
            if (topography == null)
            {
                return HttpNotFound();
            }
            return View(topography);
        }

        // POST: topographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            topography topography = db.topographys.Find(id);
            db.topographys.Remove(topography);
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
