using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agroin4.Models;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace Agroin4.Controllers
{
    public class articlesController : Controller
    {
        private webAppModel db = new webAppModel();
        //public ActionResult comment(int id)
        //{
        //    return RedirectToAction("create", "comments", new { Id = id });

        //}
        [AllowAnonymous]
        // GET: articles
        public ActionResult Index(int? id)
        {
            var articleobj = db.articles.Where(p => p.crop_id == id).ToList();
            return View(articleobj);
        }
        [AllowAnonymous]
        // GET: articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
        [Authorize(Roles = "Admin,Expert")]
        // GET: articles/Create
        public ActionResult Create()
        {
            ViewData["IdcropList"] = db.crops.Select(p => new SelectListItem() { Text = p.crop_name, Value = p.id.ToString() }).AsEnumerable();
            return PartialView();
        }

        // POST: articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( article article)
        {
            if (ModelState.IsValid)
            {
                article.expert_id = new Guid(User.Identity.GetUserId());
                article.expert_email =(User.Identity.GetUserName());
                article.date_time = DateTime.Now;
                db.articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index",new { id = article.crop_id });
            }

            return View(article);
        }
        public ActionResult message()
        {
            TempData["testmsg"] = "<script>alert('Request Denied ');</script>";
            return View();
        }
        [Authorize(Roles = "Admin,Expert")]

        // GET: articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            ViewData["IdcropList"] = db.crops.Select(p => new SelectListItem() { Text = p.crop_name, Value = p.id.ToString() }).AsEnumerable();
            article article = db.articles.Find(id);
            Guid current_id= new Guid(User.Identity.GetUserId());
            //Guid admin_id = new Guid("b4f9e79e-d000-481a-91dc-511e7f513b7a");

            if (current_id != article.expert_id)
                
            {
                return RedirectToAction("message" );

            }
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                //article.expert_email = (User.Identity.GetUserName());

                db.SaveChanges();
                return RedirectToAction("Index",new { id=article.crop_id});
            }
            return View(article);
        }

        [Authorize(Roles = "Admin,Expert")]

        // GET: articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            Guid current_id = new Guid(User.Identity.GetUserId());
            //Guid admin_id = new Guid("b4f9e79e-d000-481a-91dc-511e7f513b7a");
            

            if (current_id != article.expert_id) /*||  !( Roles.GetRolesForUser().Contains("Admin") )  )*/

            {
                return RedirectToAction("message");

            }
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            article article = db.articles.Find(id);
            db.articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index",new { id = article.crop_id });
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
