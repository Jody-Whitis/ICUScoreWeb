using ICUScore.Data.Models;
using ICUScore.Data.Services;
using ICUScore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ICUScore.Web.Controllers
{
    public class ScoreboardController : Controller
    {
        InMemoryHighscoreTable highscoreTable;
        InMemoryPlayerTable playerTable;
        InMemoryGamesTable gameTable;

        public ScoreboardController(InMemoryHighscoreTable highscoreTable,InMemoryPlayerTable playerTable,InMemoryGamesTable gameTable)
        {
            this.highscoreTable = highscoreTable;
            this.playerTable = playerTable;
            this.gameTable = gameTable;
        }

        // GET: Scoreboard
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<HighScore> highScores = highscoreTable.GetAll();
            IEnumerable<Player> players = playerTable.GetAll();
            IEnumerable<Game> games = gameTable.GetAll();
            try
            {
                var scoreboard = from h in highScores
                                 join p in players on h.pID equals p.ID
                                 join g in games on h.gID equals g.ID
                                 select new ScoreboardViewModel
                                 {
                                     Highscore = h.Highscore,
                                     PlayerName = p.Name,
                                     GameMode = g.Name,
                                     lastScored = h.LastUpdated
                                 };
                ViewBag.Title = "Scoreboard";
                return View(scoreboard);
            }
            catch
            {
                return View("Home");
            }
            
        
        }

        [HttpGet]
        public ActionResult AddScore()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddScore(HighScore newHighscore)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    newHighscore.LastUpdated = DateTime.Now;
                    highscoreTable.AddScore(newHighscore);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Model" + ModelState.IsValid.ToString());
                }


            }
            catch
            {
                return View("Error");
            }
        }
    }
}