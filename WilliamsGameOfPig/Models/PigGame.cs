using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsGameOfPig.Models
{
	/// <summary>
	/// Holds functionality to manage the Pig Game state
	///
	/// Author: Nolan Williams
	/// Date:	2/27/21
	/// </summary>
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

		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		/// <value>
		/// The user.
		/// </value>
		public PigPlayer User { get; set; }

		/// <summary>
		/// Gets or sets the computer.
		/// </summary>
		/// <value>
		/// The computer.
		/// </value>
		public PigPlayer Computer { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is the user turn.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is user turn; otherwise, <c>false</c>.
		/// </value>
		public bool IsUserTurn { get; set; }

		/// <summary>
		/// Gets the maximum score.
		/// </summary>
		/// <value>
		/// The maximum score.
		/// </value>
		public int MaxScore { get; }

		/// <summary>
		/// Gets or sets the current turn.
		/// </summary>
		/// <value>
		/// The current turn.
		/// </value>
		public PigTurn CurrentTurn { get; set; }

		/// <summary>
		/// Gets or sets the game status.
		/// </summary>
		/// <value>
		/// The game status.
		/// </value>
		public string GameStatus { get; set; }

		/// <summary>
		/// Gets or sets the current dice one.
		/// </summary>
		/// <value>
		/// The current dice one.
		/// </value>
		public int CurrentDiceOne { get; set; }

		/// <summary>
		/// Gets or sets the current dice two.
		/// </summary>
		/// <value>
		/// The current dice two.
		/// </value>
		public int CurrentDiceTwo { get; set; }

		/// <summary>
		/// Gets a value indicating whether [user has won].
		/// </summary>
		/// <value>
		///   <c>true</c> if [user has won]; otherwise, <c>false</c>.
		/// </value>
		private bool UserHasWon => this.User.Score >= this.MaxScore;

		/// <summary>
		/// Gets a value indicating whether [computer has won].
		/// </summary>
		/// <value>
		///   <c>true</c> if [computer has won]; otherwise, <c>false</c>.
		/// </value>
		private bool ComputerHasWon => this.Computer.Score >= this.MaxScore;

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="PigGame"/> class.
		/// </summary>
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

		/// <summary>
		/// Handles the game functionality for a user roll event.
		/// </summary>
		public void UserRoll()
		{
			if (!IsUserTurn || UserHasWon || ComputerHasWon) return;

			var currentRoll = this.CurrentTurn.RollDice();
			var rolledAOne = currentRoll.HasAOne;

			this.setCurrentDice(currentRoll);
			this.handleUserScoreOnRoll(rolledAOne);
			this.handleGameStatusOnUserRoll(rolledAOne);

			this.IsUserTurn = !rolledAOne;
		}

		/// <summary>
		/// Handles the game functionality for a user hold event.
		/// </summary>
		public void UserHold()
		{
			if (!IsUserTurn || UserHasWon || ComputerHasWon) return;

			this.GameStatus = UserHasHoldMsg;

			this.IsUserTurn = false;
			this.resetTurn();
		}

		/// <summary>
		/// Handles the game functionality for a computer roll event.
		/// </summary>
		public void ComputerRoll()
		{
			if (IsUserTurn || UserHasWon || ComputerHasWon) return;

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
			else
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
