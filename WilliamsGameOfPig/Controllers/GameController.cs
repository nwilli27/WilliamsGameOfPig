using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Controllers
{
	public class GameController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult NewGame()
		{
			//TODO build game state object and pass it to view with view model holding everything needed to display proper game
			return View();
		}
	}
}
