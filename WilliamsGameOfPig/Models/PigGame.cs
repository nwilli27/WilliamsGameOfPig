using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Models
{
	public class PigGame
	{
		#region Constants

		private const int DefaultMaxScore = 20;

		private const string UserTurnToRollMsg = "It's your turn to roll.";
		private const string UserRolledOneMsg = "You rolled a 1 and lost your points, now you must roll for the computer.";
		private const string UserHasHoldMsg = "You decided to hold, now you must roll for the computer.";
		private const string UserHasWonMsg = "You won!";

		private const string ComputerRolledOneMsg = "The computer rolled a one, now you can roll.";
		private const string ComputerHasWonMsg = "Oh no, Computer beat you!";

		#endregion

		#region Properties

		public PigPlayer User { get; set; }
		public PigPlayer Computer { get; set; }
		public bool IsUserTurn { get; set; }
		public int MaxScore { get; }
		public PigTurn CurrentTurn { get; set; }
		public string GameStatus { get; set; }
		public int CurrentDiceOne { get; set; }
		public int CurrentDiceTwo { get; set; }

		private bool UserHasWon => this.User.Score >= this.MaxScore;
		private bool ComputerHasWon => this.Computer.Score >= this.MaxScore;

		#endregion

		#region Construction

		public PigGame()
		{
			this.User = new PigPlayer();
			this.Computer = new PigPlayer();
			this.MaxScore = DefaultMaxScore;
			this.CurrentTurn = new PigTurn();
			this.GameStatus = UserTurnToRollMsg;
			this.IsUserTurn = true;
		}

		#endregion

		#region Public Methods

		public void UserRoll()
		{
			if (!IsUserTurn) return;

			var currentRoll = this.CurrentTurn.RollDice();
			var rolledAOne = currentRoll.HasAOne;
			this.setCurrentDice(currentRoll);
			this.handleUserScoreOnRoll(rolledAOne);
			this.handleGameStatusOnUserRoll(rolledAOne);
			this.IsUserTurn = !rolledAOne;
		}

		public void UserHold()
		{
			if (!IsUserTurn) return;

			this.IsUserTurn = false;
			this.GameStatus = UserHasHoldMsg;
			this.resetTurn();
		}

		public void ComputerRoll()
		{
			if (IsUserTurn) return;

			this.resetTurn();
			var currentRoll = this.CurrentTurn.RollDice();
			var rolledAOne = currentRoll.HasAOne;
			this.setCurrentDice(currentRoll);
			this.handleComputerScoreOnRoll(rolledAOne);
			this.handleGameStatusOnComputerRoll(rolledAOne);
			this.IsUserTurn = true;
			this.resetTurn();
		}

		#endregion

		#region Private Helpers

		private void handleUserScoreOnRoll(bool rolledAOne)
		{
			if (rolledAOne)
			{
				var isBackTo0 = this.User.Score - this.CurrentTurn.Total <= 0;
				this.User.Score = isBackTo0 ? 0 : this.User.Score - this.CurrentTurn.Total;
			}
			else if (!rolledAOne)
			{
				this.User.Score += this.CurrentTurn.CurrentRoll.DiceTotal;
			}
		}

		private void handleGameStatusOnUserRoll(bool rolledAOne)
		{
			if (rolledAOne)
			{
				this.GameStatus = UserRolledOneMsg;
			}
			else if (UserHasWon)
			{
				this.GameStatus = UserHasWonMsg;
			}
			else
			{
				this.GameStatus = $"You a rolled a total of {this.CurrentTurn.CurrentRoll.DiceTotal}, roll again or hold.";
			}
		}

		private void handleComputerScoreOnRoll(bool rolledAOne)
		{
			if (!rolledAOne)
			{
				this.Computer.Score += this.CurrentTurn.CurrentRoll.DiceTotal;
			}
		}

		private void handleGameStatusOnComputerRoll(bool rolledAOne)
		{
			if (rolledAOne)
			{
				this.GameStatus = ComputerRolledOneMsg;
			}
			else if (ComputerHasWon)
			{
				this.GameStatus = ComputerHasWonMsg;
			}
			else
			{
				this.GameStatus = $"Computer rolled a total of {this.CurrentTurn.CurrentRoll.DiceTotal}, now you can roll.";
			}
		}

		private void resetTurn()
		{
			this.CurrentTurn = new PigTurn();
		}

		private void setCurrentDice(PigRoll currentRoll)
		{
			this.CurrentDiceOne = currentRoll.DiceOne;
			this.CurrentDiceTwo = currentRoll.DiceTwo;
		}

		#endregion
	}
}
