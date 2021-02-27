using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Models
{
	[Serializable]
	public class PigRoll
	{
		#region Members

		private static readonly Random random = new Random();

		#endregion

		#region Constants

		private const int StartingDice = 1;
		private const int EndingDice = 6;

		#endregion

		#region Properties

		public int DiceOne { get; set; }
		public int DiceTwo { get; set; }
		public int DiceTotal => this.DiceOne + this.DiceTwo;
		public bool HasAOne => this.DiceOne.Equals(1) || this.DiceTwo.Equals(1);

		#endregion

		#region Public Methods

		public void RandomlyAssignDice()
		{
			this.DiceOne = getRandomRoll();
			this.DiceTwo = getRandomRoll();
		}

		#endregion

		#region Private Helpers

		private static int getRandomRoll()
		{
			return random.Next(StartingDice, EndingDice);
		} 

		#endregion
	}
}
