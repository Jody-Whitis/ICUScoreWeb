using ICUScore.Data.Models;
using ICUScore.Data.Services;
using ICUScore.Web.Models;
using ICUScore.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ICUScore.Web.Controllers
{
    public class PvPController : Controller
    {
        InMemoryPlayerTable playerTable;
        InMemoryPvPTable pvPTable;
        InMemoryGamesTable gameTable;
        
        public PvPController(InMemoryPlayerTable playerTable,InMemoryPvPTable pvPTable, InMemoryGamesTable gamesTable)
        {
            this.playerTable = playerTable;
            this.pvPTable = pvPTable;
            this.gameTable = gamesTable;
        }

        // GET: PvP
        [HttpGet]
        public ActionResult Index()
        {

            IEnumerable<PvP> pvpStats = pvPTable.GetAll();
            IEnumerable<Player> players = playerTable.GetAll();
            IEnumerable<Game> games = gameTable.GetAll();
            try
            {
                var pvpScoreboard = from s in pvpStats
                                 join p in players on s.pID equals p.ID
                                 join g in games on s.gID equals g.ID
                                 select new PvPViewModel
                                 {
                                     WinnerName = p.Name,
                                     OpponentName = s.OpponentName,
                                     GameName = g.Name,
                                     lastPlayedDate = s.LastMatch
 
                                 };
                ViewBag.Title = "PvP";
                return View(pvpScoreboard);
            }
            catch
            {
                return View("Home");
            }

        }

        [HttpGet]
        [UserAuthentication]
        public ActionResult AddPvP()
        {
            PvPViewModel players = new PvPViewModel();
            players.listOfPlayers = playerTable.GetAll(Convert.ToInt32(Session["playerID"]));
            players.listOfGames = gameTable.GetAll();
            return View(players);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthentication]
        public ActionResult AddPvP(PvP newPvPStat)
        {
            try
            {
                if (ModelState.IsValid.Equals(true))
                {
                    newPvPStat.pID = 1;
                    newPvPStat.LastMatch = DateTime.Now;
                    pvPTable.AddPvP(newPvPStat);
                    return RedirectToAction("Index");
                }
                else
                    {
                        throw new Exception("Error view");
                    }

            }
            catch
            {
                return View("Error");
            }
        }
    }
}