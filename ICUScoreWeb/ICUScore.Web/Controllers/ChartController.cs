using ICUScore.Data.Models;
using ICUScore.Data.Services;
using ICUScore.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICUScore.Web.Controllers
{
    public class ChartController : Controller
    {
        InMemoryHighscoreTable hsTable;
        InMemoryPlayerTable pTable;
        InMemoryGamesTable gTable;
        public ChartController(InMemoryPlayerTable inMemoryPlayerTable, InMemoryHighscoreTable inMemoryHighscoreTable, InMemoryGamesTable inMemoryGamesTable)
        {
            this.hsTable = inMemoryHighscoreTable;
            this.pTable = inMemoryPlayerTable;
            this.gTable = inMemoryGamesTable;
        }

        // GET: Chart
        public ActionResult Index()
        {
            IEnumerable<HighScore> highScores = new List<HighScore>();
            IEnumerable<Player> players = new List<Player>();
            IEnumerable<Game> games = new List<Game>();
            List<object> idata = new List<object>();

            highScores = hsTable.GetAll();
            players = pTable.GetAll();
            games = gTable.GetAll();
            IEnumerable<ChartViewModel> scoreBoard = (from h in highScores
                                                      join p in players on h.pID equals p.ID
                                                      join g in games on h.gID equals g.ID
                                                      select new ChartViewModel
                                                      {
                                                          Name = p.Name,
                                                          Highscore = h.Highscore,
                                                          GameType = g.Name
                                                      
                                                      });

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Score", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Game", System.Type.GetType("System.String"));

            foreach (var s in scoreBoard)
            {
            DataRow dr = dt.NewRow();

            dr["Name"] = s.Name;
            dr["Score"] = s.Highscore;
            dr["Game"] = s.GameType;

            dt.Rows.Add(dr);
            }
            


            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                idata.Add(x);
            }

            ViewBag.ChartData = idata.ToArray();
            return View("~/Views/Chart/Chart.cshtml");
        }

        [HttpPost]
        public JsonResult NewChart()
        {
            IEnumerable<HighScore> highScores = new List<HighScore>();
            IEnumerable<Player> players = new List<Player>();
            List<object> idata = new List<object>();

            highScores = hsTable.GetAll();
            players = pTable.GetAll();

            IEnumerable<ChartViewModel> scoreBoard = (from h in highScores
                                                      join p in players on h.pID equals p.ID
                                                      select new ChartViewModel
                                                      {
                                                          Name = p.Name,
                                                          Highscore = h.Highscore
                                                      });

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Score", System.Type.GetType("System.Int32"));
            DataRow dr = dt.NewRow();


            dr["Name"] = scoreBoard.ToList().First().Name;
            dr["Score"] = scoreBoard.ToList().First().Highscore;
            dt.Rows.Add(dr);


            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                idata.Add(x);
            }

            ViewBag.ChartData = idata.ToArray();
            return Json(idata, JsonRequestBehavior.AllowGet);

        }

    }


}