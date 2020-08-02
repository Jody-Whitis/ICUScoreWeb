using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICUScore.Data.Models;
using ICUScore.Data.Services;
using ICUScore.Web.Models;

namespace ICUScore.Web.Controllers
{
    public class PlayerController : Controller
    {
        InMemoryPlayerTable _playerTable;
        public PlayerController(InMemoryPlayerTable playerTable)
        {
            this._playerTable = playerTable;
        }


        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewPlayer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPlayer(Player newPlayer)
        {
            try
            {
                _playerTable.AddNewPlayer(newPlayer);
                return RedirectToAction("Index","Scoreboard");
            }
            catch
            {
                _playerTable.AddNewPlayer(newPlayer);
                return View("Error");
            }
      
        }

        [HttpGet]
        public ActionResult EditPlayer(PlayerViewModel playerViewModel)
        {
            try
            {
                IEnumerable<Player> listOfPlayers = _playerTable.GetAll();
            playerViewModel.listOfPlayers = listOfPlayers;
            return View(playerViewModel);
            }
            catch
            {
                return View("Error");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPlayer(int id, string name)
        {
            try
            {
                _playerTable.EditPlayer(id, name);
                return RedirectToAction("Index", "Scoreboard");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}