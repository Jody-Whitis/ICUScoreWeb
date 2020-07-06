using ICUScore.Data.Models;
using ICUScore.Data.Services;
using ICUScore.Web.Models;
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

        public PvPController(InMemoryPlayerTable playerTable,InMemoryPvPTable pvPTable)
        {
            this.playerTable = playerTable;
            this.pvPTable = pvPTable;
        }

        // GET: PvP
        [HttpGet]
        public ActionResult Index()
        {

            IEnumerable<PvP> pvpStats = pvPTable.GetAll();
            IEnumerable<Player> players = playerTable.GetAll();

            try
            {
                var pvpScoreboard = from s in pvpStats
                                 join p in players on s.pID equals p.ID
                                 select new PvPViewModel
                                 {
                                     WinnerName = p.Name,
                                     OpponentName = s.OpponentName,
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
        public ActionResult AddPvP()
        {
            PvPViewModel players = new PvPViewModel();
            players.listOfPlayers = playerTable.GetAll().Select(p => p.Name); 
            return View(players);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPvP(PvP newPvPStat)
        {
            try
            {
                if (ModelState.IsValid.Equals(true))
                {

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