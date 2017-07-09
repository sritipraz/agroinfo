using Agroin4.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Agroin4.Controllers
{
    public class articleController : Controller
    {
        private webAppModel db = new webAppModel();

        // GET: article
        public ActionResult Create()

        {
            ViewData["IdcropList"] = db.crops.Select(p => new SelectListItem() { Text = p.crop_name, Value = p.id.ToString() }).AsEnumerable();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(article articleobj)
        {
            if (ModelState.IsValid)
            {

                //    bool isLoggedin = Convert.ToBoolean(Session["LoggedIn"]);
                //if (isLoggedin)
                //{
                //    Session[UserId]
                //}
                
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //if (claimsIdentity != null)
                //{
                //    // the principal identity is a claims identity.
                //    // now we need to find the NameIdentifier claim
                //    var userIdClaim = claimsIdentity.Claims
                //        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                //    if (userIdClaim != null)
                //    {
                //        articleobj.expert_id = Convert.ToInt32(userIdClaim.Value);
                //    }
                //}
                articleobj.date_time = DateTime.Now;
                db.articles.Add(articleobj);

                db.SaveChanges();
                return RedirectToAction("crop","Create");
            }

            return View(articleobj);
        }

    }
}