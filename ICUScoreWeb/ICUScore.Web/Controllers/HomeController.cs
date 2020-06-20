﻿using ICUScore.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICUScore.Web.Controllers
{
    public class HomeController : Controller
    {
        InMemoryHighscoreTable db;
 
        public HomeController(InMemoryHighscoreTable db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            ViewBag.title = "Home";
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}