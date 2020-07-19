using ICUScore.Data.Models;
using ICUScore.Data.Services;
using ICUScore.Web.Models;
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
        InMemoryLoginTable lg;

        public HomeController(InMemoryHighscoreTable db, InMemoryLoginTable lg)
        {
            this.db = db;
            this.lg = lg;
        }

        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                //Validate
                Login loginUser = new Login();
                loginUser = lg.GetUser(userLogin.User, userLogin.Password).FirstOrDefault();
               
                if ((loginUser != null))
                {
                Session.Add("user", loginUser.EmailAddress);
                Session.Add("name", loginUser.Name);
                Session.Add("id", loginUser.ID);
                Session.Add("sessionGUID", Guid.NewGuid());
               
                return RedirectToAction("Index", "Scoreboard");
                }
                else
                {
                    ModelState.AddModelError("login", "Login Incorrect");
                    return View();
                }
              
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
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