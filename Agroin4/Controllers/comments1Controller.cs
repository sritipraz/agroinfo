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

namespace Agroin4.Controllers
{
    public class comments1Controller : Controller
    {
        private webAppModel db = new webAppModel();

        public ActionResult SaveComments(int id,string commenty)
            {
            comment commentobj = new comment();
        commentobj.user_id = new Guid(User.Identity.GetUserId());
                commentobj.user_email = (User.Identity.GetUserName());
                commentobj.TimeOfPost = DateTime.Now;
            commentobj.article_id = id;
            commentobj.comment_text = commenty;
                db.comments.Add(commentobj);
                db.SaveChanges();
            //return RedirectToAction("index","comments1",new { id=Id });
             return Json(new { redirectUrl = "/articles/Details", Id = id }, JsonRequestBehavior.AllowGet);

        }


        //public ActionResult Reply(int? id)
        //{
        //    comment commentobj = new comment();
        //    commentobj.user_id = new Guid(User.Identity.GetUserId());
        //    return View(commentobj);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Reply(comment model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        model.TimeOfPost = DateTime.Now;
        //        db.comments.Add(model);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}

        // GET: comments1
        public ActionResult Index(int Id)
        {
            var comments = db.comments.OrderBy(p =>p.TimeOfPost).Where(p => p.article_id == Id);//.Include(c => c.article).Include(c => c.Comment);
            return PartialView(comments.ToList());
        }

        // GET: comments1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: comments1/Create
        public ActionResult Create(int id)
        {
            comment commentobj = new comment() { article_id = id };
           // ViewBag.article_id = new SelectList(db.articles, "id", "article_name");
           // ViewBag.parentComment = new SelectList(db.comments, "id", "comment_text");
            return PartialView(commentobj);
        }

        // POST: comments1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.user_id = new Guid(User.Identity.GetUserId());
                comment.user_email = (User.Identity.GetUserName());
                comment.TimeOfPost = DateTime.Now;
                
                db.comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.article_id = new SelectList(db.articles, "id", "article_name", comment.article_id);
           // ViewBag.parentComment = new SelectList(db.comments, "id", "comment_text", comment.parentComment);
            return View(comment);
        }

        // GET: comments1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.article_id = new SelectList(db.articles, "id", "article_name", comment.article_id);
           // ViewBag.parentComment = new SelectList(db.comments, "id", "comment_text", comment.parentComment);
            return View(comment);
        }

        // POST: comments1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,user_id,comment_text,TimeOfPost,parentComment,article_id")] comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.article_id = new SelectList(db.articles, "id", "article_name", comment.article_id);
            //ViewBag.parentComment = new SelectList(db.comments, "id", "comment_text", comment.parentComment);
            return View(comment);
        }

        // GET: comments1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: comments1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comment comment = db.comments.Find(id);
            db.comments.Remove(comment);
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
