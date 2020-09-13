using ICUScore.Data.Models;
using ICUScore.Data.Services;
using ICUScore.Web.Models;
using ICUScore.Web.Services;
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
        InMemoryHighscoreTable hsTable;
        InMemoryPvPTable plTable;
        InMemoryPlayerTable playerTable;

        public HomeController(InMemoryHighscoreTable db, InMemoryLoginTable lg, InMemoryPvPTable plTable,InMemoryHighscoreTable hsTable,InMemoryPlayerTable playerTable)
        {
            this.db = db;
            this.lg = lg;
            this.hsTable = hsTable;
            this.plTable = plTable;
            this.playerTable = playerTable;
        }

        [HttpGet]
        [UserAuthentication]
        public ActionResult HomePage(HomeViewModel homeViewModel)
        {
            IEnumerable< HighScore> highScores = hsTable.GetAll() ;
            IEnumerable< PvP> pvpStats = plTable.GetAll() ;

            try
            {
                int iD =Convert.ToInt32( Session["id"]);
                PvP userPVP = pvpStats.Where(p => p.ID == iD).FirstOrDefault();
                HighScore userHS = highScores.Where(h => h.pID == iD).FirstOrDefault();
                homeViewModel.highScore = userHS;
                homeViewModel.pvpStat = userPVP;
                homeViewModel.Name = Convert.ToString(Session["name"]);
                 return View(homeViewModel);
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
          if((Session.Keys.Count > 0) && (!string.IsNullOrEmpty(Session["sessionGUID"].ToString())))
            {
                return RedirectToAction("HomePage");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                //Validate
                Login loginUser = new Login();
                loginUser = lg.GetUser(userLogin.User, userLogin.Password).FirstOrDefault();
                Player playerRegistered = new Player();


                if ((loginUser != null))
                {
                    playerRegistered = playerTable.GetPlayer(loginUser.pID);
                    Session.Add("user", loginUser.EmailAddress);
                    Session.Add("name", playerRegistered.Name);
                    Session.Add("id", loginUser.ID);
                    Session.Add("playerID", loginUser.pID);
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