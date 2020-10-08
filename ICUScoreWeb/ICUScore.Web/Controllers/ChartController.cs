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

        public ChartController(InMemoryPlayerTable inMemoryPlayerTable, InMemoryHighscoreTable inMemoryHighscoreTable)
        {
            this.hsTable = inMemoryHighscoreTable;
            this.pTable = inMemoryPlayerTable;
        }

        // GET: Chart
        public ActionResult Index()
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

            foreach(var s in scoreBoard)
            {
            DataRow dr = dt.NewRow();

            dr["Name"] = s.Name;
            dr["Score"] = s.Highscore;
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