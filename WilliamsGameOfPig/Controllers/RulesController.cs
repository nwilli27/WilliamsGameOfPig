using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WilliamsGameOfPig.Controllers
{
	/// <summary>
	/// Holds actions for the rules controller
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class RulesController : Controller
	{

		/// <summary>
		/// The default/home page for the Rules controller.
		/// </summary>
		/// <returns>Returns the home page for the rules.</returns>
		public IActionResult Index()
		{
			return View();
		}
	}
}
