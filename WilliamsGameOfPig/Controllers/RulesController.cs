using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WilliamsGameOfPig.Controllers
{
	public class RulesController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
	}
}
