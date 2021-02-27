using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Models
{
	[Serializable]
	public class PigTurn
	{
		#region Properties

		public IList<PigRoll> Rolls { get; set; }
		public int Total => this.Rolls.Sum(roll => roll.DiceTotal);
		public PigRoll CurrentRoll => Rolls.Any() ? Rolls.Last() : new PigRoll();

		#endregion

		#region Construction

		public PigTurn()
		{
			this.Rolls = new List<PigRoll>();
		}

		#endregion

		#region Public Methods

		public bool RollDice()
		{
			var currentRoll = new PigRoll();
			currentRoll.RandomlyAssignDice();
			this.Rolls.Add(currentRoll);
			return currentRoll.HasAOne;
		}

		#endregion
	}
}
