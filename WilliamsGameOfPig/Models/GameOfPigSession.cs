using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WilliamsGameOfPig.Models.Extensions;

namespace WilliamsGameOfPig.Models
{
	/// <summary>
	/// Handles the session for the Pig Game
	///
	/// Author: Nolan Williams
	/// Date:	2/27/21
	/// </summary>
	public class GameOfPigSession
	{
		#region Constants

		private const string PigGameKey = "piggamestate";

		#endregion

		#region Members

		private readonly ISession session;

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="GameOfPigSession"/> class.
		/// </summary>
		/// <param name="session">The session.</param>
		public GameOfPigSession(ISession session)
		{
			this.session = session;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Sets the pig game in the session.
		/// </summary>
		/// <param name="game">The game.</param>
		public void SetPigGame(PigGame game)
		{
			session.SetObject(PigGameKey, game);
		}

		/// <summary>
		/// Gets the pig game.
		/// </summary>
		/// <returns>
		/// Returns the PigGame object from the session, if null creates new one.
		/// </returns>
		public PigGame GetPigGame()
		{
			var pigGame = session.GetObject<PigGame>(PigGameKey);
			return pigGame ?? new PigGame();
		}

		#endregion
	}
}
