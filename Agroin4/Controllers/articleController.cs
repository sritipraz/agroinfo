﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agroin4.Controllers
{
    public class articleController : Controller
    {
        // GET: article
        public ActionResult Index()
        {
            return View();
        }
    }
}