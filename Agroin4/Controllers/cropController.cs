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
            //if (ModelState.IsValid)
            //{
                
                return RedirectToAction("search1", new { model = modelobj });
            //}

            //return View(modelobj);
            //var cropModel = db.crops.Where(p => p.topography_id == modelobj.topography_id && p.season_id== modelobj.season_id).ToList();
            //return View(cropModel);

        }

        public ActionResult search1(Models.crop modelobj)
        {
            var cropModel = db.crops.Where(p => p.topography_id == modelobj.topography_id 
                                && p.season_id == modelobj.season_id).ToList();
            return View(cropModel.ToList());

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