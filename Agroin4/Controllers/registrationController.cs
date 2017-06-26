using Agroin4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agroin4.Controllers
{
    public class registrationController : Controller
    {
        private webAppModel db = new webAppModel();
        // GET: registration
        public ActionResult Register()
        {
            ViewData["IdTypeList"] = db.typedefs.Select(p => new SelectListItem() { Text = p.type_name, Value = p.id.ToString() }).AsEnumerable();
            return View();
        }
        [HttpPost]

        public ActionResult Register(registration modelobj)
        {
           
            if (ModelState.IsValid)
            {
                //check if user exists
                var tmp = db.registrations.Where(p => p.Username == modelobj.Username).FirstOrDefault();
               
                if (tmp == null) //doesnot exists
                {
                    db.registrations.Add(modelobj.User);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("UserExists", "User already exists");
                    return View(modelobj);
                }
            }
            return View(modelobj);
        }




        
    }
    }

    

