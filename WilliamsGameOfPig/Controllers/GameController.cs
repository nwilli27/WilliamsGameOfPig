using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WilliamsGameOfPig.Models;

namespace WilliamsGameOfPig.Controllers
{
	/// <summary>
	/// The controller for the Game page.
	///
	/// Author: Nolan Williams
	/// Date:	2/27/21
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class GameController : Controller
	{

		/// <summary>
		/// The default action for Game page.
		/// </summary>
		/// <returns>Default home page view.</returns>
		public IActionResult Index()
		{
			return View(new PigGameViewModel());
		}

		/// <summary>
		/// The current game state page.
		/// Redirected to by other actions to maintain
		/// game state through refreshing etc.
		/// </summary>
		/// <returns>Redirects to the index page.</returns>
		public IActionResult Game()
		{
			return RedirectToAction("Index", new PigGameViewModel());
		}

		/// <summary>
		/// Handles new game action and redirect to game page.
		/// </summary>
		/// <returns>Redirects to Game page after updating game state.</returns>
		public IActionResult NewGame()
		{
			var session = new GameOfPigSession(HttpContext.Session);

			session.SetPigGame(new PigGame());

			return RedirectToAction("Game");
		}

		/// <summary>
		/// Handles user roll action and redirects to game page.
		/// </summary>
		/// <returns>Redirect to Game Page after updating game state.</returns>
		public IActionResult UserRoll()
		{
			var session = new GameOfPigSession(HttpContext.Session);

			var pigGame = session.GetPigGame();
			pigGame.UserRoll();
			session.SetPigGame(pigGame);

			return RedirectToAction("Game");
		}

		/// <summary>
		/// Handles computer roll action and redirects to game page.
		/// </summary>
		/// <returns>Redirect to Game Page after updating game state.</returns>
		public IActionResult ComputerRoll()
		{
			var session = new GameOfPigSession(HttpContext.Session);

			var pigGame = session.GetPigGame();
			pigGame.ComputerRoll();
			session.SetPigGame(pigGame);

			return RedirectToAction("Game");
		}

		/// <summary>
		/// Handles user hold action and redirects to game page.
		/// </summary>
		/// <returns>Redirect to Game Page after updating game state.</returns>
		public IActionResult Hold()
		{
			var session = new GameOfPigSession(HttpContext.Session);

			var pigGame = session.GetPigGame();
			pigGame.UserHold();
			session.SetPigGame(pigGame);

			return RedirectToAction("Game");
		}
	}
}
