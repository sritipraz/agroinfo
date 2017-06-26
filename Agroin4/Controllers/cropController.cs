using Agroin4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agroin4.Controllers
{
    public class cropController : Controller
    {
        private webAppModel db = new webAppModel();
        // GET: crop
        public ActionResult search()
        {
            ViewData["IdTopographyList"] = db.topographys.Select(p => new SelectListItem() { Text = p.topography_name, Value = p.id.ToString() }).AsEnumerable();
            //ViewData["IdseasonList"] = db.seasondefs.Select(p => new SelectListItem() { Text = p.season_name, Value = p.id.ToString() }).AsEnumerable();
          


            return View();
        }
        [HttpPost]
        public ActionResult search(topography modelobj)
        {
            var topographyModel = db.topographys.Include("crops").Single(p => p.id == modelobj.id);
            return View(topographyModel);

        }
    }
}