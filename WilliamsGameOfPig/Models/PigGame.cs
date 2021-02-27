using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Models
{
	[Serializable]
	public class PigGame
	{
		#region Constants

		private const int DefaultMaxScore = 20;

		private const string UserTurnToRoll = "It's your turn to roll.";
		private const string UserRollAgainStatus = "You can roll again or hold.";
		private const string UserRolledOne = "You rolled a one, now you must roll for the computer.";
		private const string UserHasHold = "You decided to hold, now you must roll for the computer.";
		private const string ComputerRolledOne = "The computer rolled a one, now you can roll.";
		private const string ComputerDidNotRollOne = "The computer did not a roll a one, now you can roll.";

		#endregion

		#region Properties

		public PigPlayer User { get; set; }
		public PigPlayer Computer { get; set; }
		public bool IsUserTurn { get; set; }
		public int MaxScore { get; }
		public PigTurn CurrentTurn { get; set; }
		public string GameStatus { get; set; }

		#endregion

		#region Construction

		public PigGame()
		{
			this.User = new PigPlayer();
			this.Computer = new PigPlayer();
			this.MaxScore = DefaultMaxScore;
			this.CurrentTurn = new PigTurn();
			this.GameStatus = UserTurnToRoll;
			this.IsUserTurn = true;
		}

		#endregion

		#region Public Methods

		public void UserRoll()
		{
			if (!IsUserTurn) return;

			var rolledAOne = this.CurrentTurn.RollDice();
			this.handleUserScoreOnRoll(rolledAOne);
			this.GameStatus = rolledAOne ? UserRolledOne : UserRollAgainStatus;
			this.IsUserTurn = !rolledAOne;
		}

		public void UserHold()
		{
			if (!IsUserTurn) return;

			this.IsUserTurn = false;
			this.GameStatus = UserHasHold;
		}

		public void ComputerRoll()
		{
			if (IsUserTurn) return;

			var rolledAOne = this.CurrentTurn.RollDice();
			this.Computer.Score += rolledAOne ? 0 : this.CurrentTurn.CurrentRoll.DiceTotal;
			this.GameStatus = rolledAOne ? ComputerRolledOne : ComputerDidNotRollOne;
			this.IsUserTurn = true;
		}

		#endregion

		#region Private Helpers

		private void resetTurn()
		{
			this.CurrentTurn = new PigTurn();
		}

		private void handleUserScoreOnRoll(bool rolledAOne)
		{
			if (rolledAOne)
			{
				this.User.Score -= this.CurrentTurn.Total;
				this.User.Score = this.User.Score < 0 ? 0 : this.User.Score;
			}
			else
			{
				this.User.Score += this.CurrentTurn.CurrentRoll.DiceTotal;
			}
		}

		#endregion
	}
}
