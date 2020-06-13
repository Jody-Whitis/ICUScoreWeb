using ICUScore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICUScore.Web.Controllers
{
    public class ScoreboardController : Controller
    {
        // GET: Scoreboard
        [HttpGet]
        public ActionResult Index(int id)
        {
            var model = new ScoreboardViewModel();
            model.PlayerID = id;
            if (model.PlayerID > -1)
            {
                return View(model);

            }
            else
            {
                return View("Home");
            }
        
        }
    }
}