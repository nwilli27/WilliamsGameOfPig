using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Models
{
	public class PigGameViewModel
	{
		#region Public Methods

		public string GetDiceImagePath(int diceValue)
		{
			if (diceValue >= 1 && diceValue <= 6)
			{
				return $"https://mdbootstrap.com/img/snippets/dice-{diceValue}.png";
			}

			return string.Empty;
		}

		public string GetProgressBarPercentage(int score, int maxScore)
		{
			var percent = (double) score / (double) maxScore * 100;
			return $"{percent}%";
		}

		#endregion
	}
}
