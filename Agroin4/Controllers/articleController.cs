using Agroin4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agroin4.Controllers
{
    public class articleController : Controller
    { private webAppModel db = new webAppModel();
    
        // GET: article
        public ActionResult Create()

        {
            ViewData["IdcropList"] = db.crops.Select(p => new SelectListItem() { Text = p.crop_name, Value = p.id.ToString() }).AsEnumerable();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( article articleobj)
        {
            if (ModelState.IsValid)
            {
                db.articles.Add(articleobj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articleobj);
        }

    }
}