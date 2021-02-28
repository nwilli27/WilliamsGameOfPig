using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Models
{
	/// <summary>
	/// Holds functionality needed for a turn in Pig
	///
	/// Author: Nolan Williams
	/// Date:	2/27/21
	/// </summary>
	public class PigTurn
	{
		#region Properties

		/// <summary>
		/// Gets or sets the list of dice rolls.
		/// </summary>
		/// <value>
		/// The dice rolls.
		/// </value>
		public IList<PigRoll> Rolls { get; set; }

		/// <summary>
		/// Gets the sum of dice rolls.
		/// </summary>
		/// <value>
		/// The sum of the dice rolls.
		/// </value>
		public int Total => this.Rolls.Sum(roll => roll.DiceTotal);

		/// <summary>
		/// Gets the current roll.
		/// </summary>
		/// <value>
		/// The current roll.
		/// </value>
		public PigRoll CurrentRoll => Rolls.Any() ? Rolls.Last() : new PigRoll();

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="PigTurn"/> class.
		/// </summary>
		public PigTurn()
		{
			this.Rolls = new List<PigRoll>();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Handles the functionality for a dice roll.
		/// Deals with assigning random values 1-6 &
		/// adding the roll if it doesn't have a 1.
		/// </summary>
		/// <returns>The roll that was created.</returns>
		public PigRoll RollDice()
		{
			var currentRoll = new PigRoll();
			currentRoll.RandomlyAssignDice();

			if (!currentRoll.HasAOne)
			{
				this.Rolls.Add(currentRoll);
			}

			return currentRoll;
		}

		#endregion
	}
}
