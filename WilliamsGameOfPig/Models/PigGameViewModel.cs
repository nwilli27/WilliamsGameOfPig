using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Models
{
	/// <summary>
	/// Holds functionality needed for the Pig Game view
	///
	/// Author: Nolan Williams
	/// Date:	2/27/21
	/// </summary>
	public class PigGameViewModel
	{
		#region Public Methods

		/// <summary>
		/// Gets the bootstrap dice image path based on the given [diceValue].
		/// </summary>
		/// <param name="diceValue">The dice value.</param>
		/// <returns>The bootstrap dice image path.</returns>
		public string GetBootstrapDiceImagePath(int diceValue)
		{
			if (diceValue >= 1 && diceValue <= 6)
			{
				return $"https://mdbootstrap.com/img/snippets/dice-{diceValue}.png";
			}

			return string.Empty;
		}

		/// <summary>
		/// Gets the score percentage based on the given [score] & [maxScore].
		/// </summary>
		/// <param name="score">The score.</param>
		/// <param name="maxScore">The maximum score.</param>
		/// <returns>The scores percentage based on the max score.</returns>
		public string GetScorePercentage(int score, int maxScore)
		{
			var percent = (double) score / (double) maxScore * 100;
			percent = percent > 100 ? 100 : percent;
			return $"{percent}%";
		}

		#endregion
	}
}
