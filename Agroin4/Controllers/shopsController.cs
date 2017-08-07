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
            var shops = db.shops.Include(c => c.districts);
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
            return View();
        }
        [Authorize(Roles = "Admin")]

        // GET: shops/Create
        public ActionResult Create()
        {
           // ViewData["DistrictIdList"] = db.districts.Select(p => new SelectListItem() { Text = p.district_name, Value = p.id.ToString() }).AsEnumerable();
            ViewData["IdDistrictList"] = db.districts.Select(p => new SelectListItem() { Text = p.district_name, Value = p.id.ToString() }).AsEnumerable();

            return View();
        }

        // POST: shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( shop shop)
        {
            if (ModelState.IsValid)
            {
                db.shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("HR_COE");
            }

            return View(shop);
        }

        public ContentResult HR_COE()
        {
            return Content("<script language='javascript' type='text/javascript'>alert     ('Requested Successfully ');</script>");
        }
        public ActionResult message()
        {
            TempData["testmsg"] = "<script>alert('Requested Successfully ');</script>";
            return View();
        }

        [Authorize(Roles = "Admin")]

        // GET: shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["IdDistrictList"] = db.districts.Select(p => new SelectListItem() { Text = p.district_name, Value = p.id.ToString() }).AsEnumerable();

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
        [Authorize(Roles = "Admin")]

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
        public ActionResult search(shop modelobj)
        {
            int id1 = modelobj.district_id;
            return RedirectToAction("search1", new { Id=id1});
            //passing model obj ta search1(action result) to send the value of district_id 
            //choosed by user

        }

        public ActionResult search1(int Id)
        {
            var shopModel = db.shops.Where(p => p.district_id == Id).ToList();
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
