using Agroin4.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agroin4.Controllers
{
    [Authorize(Roles = "Admin")]

    public class UserRolesController : Controller
    {
        private Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        // GET: UserRoles
        public ActionResult Index()
        {
            List<Models.UserRolesViewModel> list = new List<Models.UserRolesViewModel>();
            var tmplist = db.Users.ToList();
            foreach (var item in tmplist)
            {
                var user = new Models.UserRolesViewModel()
                {
                    UserName = item.UserName,
                    UserId=item.Id
                };
                foreach (var items in item.Roles)
                {
                    var tmps = db.Roles.Where(p => p.Id == items.RoleId);
                    user.RoleName.Add(tmps.FirstOrDefault().Name);
                }
                list.Add(user);
               
            }
            return View(list);
        }

        public ActionResult AddUserToRoles(string userd)
        {
           Models.UserRolesViewModel specificUser = new Models.UserRolesViewModel();
            var tmplist = db.Users.Where(p=>p.Id==userd).FirstOrDefault();
            specificUser.UserId = tmplist.Id;
            specificUser.UserName = tmplist.UserName;
            foreach (var items in tmplist.Roles)
            {
                specificUser.RoleName.Add(db.Roles.Where(p => p.Id == items.RoleId).FirstOrDefault().Name);
            }
            var tmp = db.Roles.ToList().Select(p => new SelectListItem() { Text = p.Name, Value = p.Name, Selected = tmplist.Roles.Where(q => q.RoleId == p.Id).Count() > 0 });
            ViewData["Roles"] = db.Roles.ToList().Select(p => new SelectListItem() { Text = p.Name, Value = p.Name,Selected=tmplist.Roles.Where(q=>q.RoleId==p.Id).Count()>0 });           
            return View(specificUser);
        }

        [HttpPost]
        public ActionResult AddUserToRoles(Models.UserRolesViewModel user)
        {

            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roles = db.Users.Find(user.UserId).Roles;
            List<string> tmp = new List<string>();
            foreach (var item in roles)
            {
                tmp.Add(db.Roles.Find(item.RoleId).Name);
            }
            usermanager.RemoveFromRoles(user.UserId, tmp.ToArray());
            usermanager.AddToRoles(user.UserId, user.RoleName.ToArray());
            return RedirectToAction("Index");
        }
    }
}