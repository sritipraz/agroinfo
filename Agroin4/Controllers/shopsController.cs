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
    public class shopsController : Controller
    {
        private webAppModel db = new webAppModel();

        // GET: shops
        public ActionResult Index()
        {
            return View(db.shops.ToList());
        }

        // GET: shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shop shop = db.shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: shops/Create
        public ActionResult Create()
        {
            ViewData["IdDistrictList"] = db.districts.Select(p => new SelectListItem() { Text = p.district_name, Value = p.id.ToString() }).AsEnumerable();
            return View();
        }

        // POST: shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,shop_name,district_id,address,contact,email")] shop shop)
        {
            if (ModelState.IsValid)
            {
                db.shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shop);
        }

        // GET: shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shop shop = db.shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,shop_name,district_id,address,contact,email")] shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        // GET: shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shop shop = db.shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            shop shop = db.shops.Find(id);
            db.shops.Remove(shop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult search()
        {
            ViewData["IdDistrictList"] = db.districts.Select(p => new SelectListItem() { Text = p.district_name, Value = p.id.ToString() }).AsEnumerable();
           


            return View();
        }
        [HttpPost]
        public ActionResult search(crop modelobj)
        {
            

            return RedirectToAction("search1", new { model = modelobj });
            

        }

        public ActionResult search1(Models.shop modelobj)
        {
            var shopModel = db.shops.Where(p => p.district_id == modelobj.district_id).ToList();
            return View(shopModel);

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
