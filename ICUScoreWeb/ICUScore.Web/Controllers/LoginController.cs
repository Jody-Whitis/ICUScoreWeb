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
using ICUScore.Web.Services;

namespace ICUScore.Web.Controllers
{
    [UserAuthentication]
    public class LoginController : Controller
    {
        InMemoryLoginTable loginTable;
        InMemoryPlayerTable playerTable;

        public LoginController(InMemoryLoginTable loginTable, InMemoryPlayerTable playerTable)
        {
            this.loginTable = loginTable;
            this.playerTable = playerTable;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Register a player name to a login account
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RegisterLogin(LoginViewModel loginViewModel)
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

        /// <summary>
        /// Hard-coded email and pass word for testing registration
        /// </summary>
        /// <param name="registerLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterLogin(Data.Models.Login registerLogin)
        {
            try
            {
                List<Player> players = playerTable.GetAllRegistered(false).ToList();
                registerLogin.Password = "test";
                //populate name from list
                registerLogin.Name = players.Where(p => p.ID == registerLogin.pID).Select(p => p.Name).FirstOrDefault();
                registerLogin.EmailAddress = registerLogin.Name + "@test.com";
                if (players.Where(p => p.ID == registerLogin.pID).Any())
                {
                    playerTable.RegisterPlayer(registerLogin.pID);
                }
                loginTable.AddNewUser(registerLogin);
                return RedirectToAction("Index", "Scoreboard");
            }
            catch
            {
                return View("Error");
            }
        }

        /// <summary>
        /// Delete from the logins table, unregisters name to a login account
        /// set registration bit to 0
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UnRegisterLogin(LoginViewModel loginViewModel)
        {
            if ((Session.Keys.Count > 0) && (!string.IsNullOrEmpty(Session["sessionGUID"].ToString())))
            {
                Data.Models.Login loginUserProfile = loginTable.SelectUser(Convert.ToInt32(Session["id"]));
                loginViewModel.login = loginUserProfile;
                return View(loginViewModel);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnRegisterLogin(Data.Models.Login unRegisterLogin)
        {
            if ((Session.Keys.Count > 0) && (!string.IsNullOrEmpty(Session["sessionGUID"].ToString())))
            {
                Int32 loginID = Convert.ToInt32(Session["id"]);
                Data.Models.Login login = loginTable.SelectUser(loginID);
                Int32 playerID = login.pID;
                //Delete from Logins
                loginTable.UnregisterUser(login);
                //Set the registered bit to 0 in Players
                playerTable.UnRegisterPlayer(playerID);
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                throw new Exception("Session ID not found");
            }
        }
    }
}