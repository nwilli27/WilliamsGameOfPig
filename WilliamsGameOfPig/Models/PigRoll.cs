using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Models
{
	/// <summary>
	/// Holds functionality for a roll in Pig
	///
	/// Author: Nolan Williams
	/// Date:	2/27/21
	/// </summary>
	public class PigRoll
	{
		#region Members

		private static readonly Random Random = new Random();

		#endregion

		#region Constants

		private const int StartingDice = 1;
		private const int EndingDice = 7;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the dice one.
		/// </summary>
		/// <value>
		/// The dice one.
		/// </value>
		public int DiceOne { get; set; }

		/// <summary>
		/// Gets or sets the dice two.
		/// </summary>
		/// <value>
		/// The dice two.
		/// </value>
		public int DiceTwo { get; set; }

		/// <summary>
		/// Gets the dice total.
		/// </summary>
		/// <value>
		/// The dice total.
		/// </value>
		public int DiceTotal => this.DiceOne + this.DiceTwo;

		/// <summary>
		/// Gets a value indicating whether this instance has a one.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has a one; otherwise, <c>false</c>.
		/// </value>
		public bool HasAOne => this.DiceOne.Equals(1) || this.DiceTwo.Equals(1);

		#endregion

		#region Public Methods

		/// <summary>
		/// Randomly assigns a value to each of the dice between 1-6.
		/// </summary>
		public void RandomlyAssignDice()
		{
			this.DiceOne = getRandomRoll();
			this.DiceTwo = getRandomRoll();
		}

		#endregion

		#region Private Helpers

		private static int getRandomRoll()
		{
			return Random.Next(StartingDice, EndingDice);
		} 

		#endregion
	}
}
