using Agroin4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agroin4.Controllers
{
    public class login_asController : Controller
    {
        // GET: login_as

        private webAppModel db = new webAppModel();
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(login_as modelobj)
        {
            if (ModelState.IsValid)
            {
                var tmp = db.registrations.Where(p => p.Username == modelobj.Username).FirstOrDefault();

                //check if user exists
                if (tmp != null)
                {
                    //check if password match
                    if (tmp.Password == modelobj.Password)
                    {
                        Session.Add("LoggedIn", true);
                        Session.Add("Username", tmp.Username);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("PasswordError", "Password not matched.");
                        return View(modelobj);
                    }
                }
                else
                {
                    ModelState.AddModelError("UserError", "User does not exists");
                    return View(modelobj);
                }
            }

            return View(modelobj);
        }

    }
}