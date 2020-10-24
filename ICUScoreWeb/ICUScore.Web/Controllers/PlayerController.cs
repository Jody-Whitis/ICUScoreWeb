using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICUScore.Data.Models;
using ICUScore.Data.Services;
using ICUScore.Web.Models;
using ICUScore.Web.Services;

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
        [UserAuthentication]
        public ActionResult NewPlayer()
        {
            return View();
        }

        /// <summary>
        /// Add a new player name
        /// </summary>
        /// <param name="newPlayer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthentication]
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
        [UserAuthentication]
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

        /// <summary>
        /// Update player name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthentication]
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