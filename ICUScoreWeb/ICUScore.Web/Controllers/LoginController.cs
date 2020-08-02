using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using ICUScore.Data.Models;
using ICUScore.Data.Services;
using ICUScore.Web.Models;

namespace ICUScore.Web.Controllers
{
    public class LoginController : Controller
    {
        InMemoryLoginTable loginTable;
        InMemoryPlayerTable playerTable;

        public LoginController(InMemoryLoginTable loginTable,InMemoryPlayerTable playerTable)
        {
            this.loginTable = loginTable;
            this.playerTable = playerTable;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewLogin(LoginViewModel loginViewModel)
        {
            try
            {
                loginViewModel.listOfPlayers = playerTable.GetAllRegistered(false);
                return View(loginViewModel);
            }
            catch
            {
            return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewLogin(Data.Models.Login newLogin)
        {
            try
            {
                List<Player> players = playerTable.GetAllRegistered(false).ToList();
                if(players.Where(p => p.ID == newLogin.pID).Any())
                {
                    playerTable.RegisterPlayer(newLogin.pID);
                }
                loginTable.AddNewUser(newLogin);
                return RedirectToAction("Index", "Scoreboard");
            }
            catch
            {
                return View("Error");
            }
        }

    }
}