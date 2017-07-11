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
            ViewData["IdTopographyList"] = db.topographys.Select(p => new SelectListItem(){ Text = p.topography_name, Value = p.id.ToString() }).AsEnumerable();
            ViewData["IdseasonList"] = db.seasondefs.Select(p => new SelectListItem() { Text = p.season_name, Value = p.id.ToString() }).AsEnumerable();
          


            return View();
        }
        [HttpPost]
        public ActionResult search(crop modelobj)
        {
            int id1 = modelobj.topography_id;
            int id2 = modelobj.season_id;

            return RedirectToAction("search1", new { Id1=id1,Id2=id2 });
            

        }

        public ActionResult search1(int Id1,int Id2)
        {
            var cropModel = db.crops.Where(p => p.topography_id == Id1 
                                && p.season_id == Id2).ToList();
            return View(cropModel);

        }

        //public ActionResult viewdata(Models.crop modelobj)
        //{
        //    return View(modelobj);

        //}



        public ActionResult Create()
        {
                ViewData["IdCropList"] = db.crops.Select(p => new SelectListItem() { Text = p.crop_name, Value = p.id.ToString() }).AsEnumerable();

            ViewData["IdTopographyList"] = db.topographys.Select(p => new SelectListItem() { Text = p.topography_name, Value = p.id.ToString() }).AsEnumerable();
                ViewData["IdSeasonList"] = db.seasondefs.Select(p => new SelectListItem() { Text = p.season_name, Value = p.id.ToString() }).AsEnumerable();

                return View();
            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(crop crop)
        {
            if (ModelState.IsValid)
            {
                db.crops.Add(crop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crop);
        }
    }
}