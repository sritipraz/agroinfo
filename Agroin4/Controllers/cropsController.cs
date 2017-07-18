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
    public class cropsController : Controller
    {
        private webAppModel db = new webAppModel();

        // GET: crops
        public ActionResult Index()
        {
            var cropVM = db.crops.Select(p => new CropViewModel() { crop_name = p.crop_name, id = p.id, season_id = p.season_id, topography_id = p.topography_id, topography_Name = p.topographys.topography_name, season_Name = p.Season.season_name });
        
            return View(cropVM);
        }

        // GET: crops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crop crop = db.crops.Find(id);
            if (crop == null)
            {
                return HttpNotFound();
            }
            return View(crop);
        }

        // GET: crops/Create
        public ActionResult Create()
        {
            ViewData["IdSeasonList"] = db.seasondefs.Select(p => new SelectListItem() { Text = p.season_name, Value = p.id.ToString() }).AsEnumerable();
            ViewData["IdTopographyList"] = db.topographys.Select(p => new SelectListItem() { Text = p.topography_name, Value = p.id.ToString() }).AsEnumerable();
            //ViewBag.topography_id = new SelectList(db.topographys, "id", "topography_name");
            return View();
        }

        // POST: crops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( crop crop)
        {
            if (ModelState.IsValid)
            {
                db.crops.Add(crop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.topography_id = new SelectList(db.topographys, "id", "topography_name", crop.topography_id);
            return View(crop);
        }

        // GET: crops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["IdSeasonList"] = db.seasondefs.Select(p => new SelectListItem() { Text = p.season_name, Value = p.id.ToString() }).AsEnumerable();
            ViewData["IdTopographyList"] = db.topographys.Select(p => new SelectListItem() { Text = p.topography_name, Value = p.id.ToString() }).AsEnumerable();
            crop crop = db.crops.Find(id);
            if (crop == null)
            {
                return HttpNotFound();
            }
           // ViewBag.topography_id = new SelectList(db.topographys, "id", "topography_name", crop.topography_id);
            return View(crop);
        }

        // POST: crops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,crop_name,topography_id,season_id")] crop crop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.topography_id = new SelectList(db.topographys, "id", "topography_name", crop.topography_id);
            return View(crop);
        }

        // GET: crops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crop crop = db.crops.Find(id);
            if (crop == null)
            {
                return HttpNotFound();
            }
            return View(crop);
        }

        // POST: crops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            crop crop = db.crops.Find(id);
            db.crops.Remove(crop);
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
