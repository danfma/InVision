using System;
using System.Threading;
using InVision.GameMath;
using Karel.Flow;

namespace Karel.Controller
{
	public class Karel
	{
		/// <summary>
		/// Gets the karel robot.
		/// </summary>
		/// <value>The karel robot.</value>
		private static KarelRobot KarelRobot
		{
			get { return KarelGameFlow.World.Karel; }
		}

		/// <summary>
		/// Gets or sets the direction.
		/// </summary>
		/// <value>The direction.</value>
		public KarelDirection Direction
		{
			get { return KarelRobot.Direction; }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to north].
		/// </summary>
		/// <value><c>true</c> if [looking to north]; otherwise, <c>false</c>.</value>
		public bool LookingToNorth
		{
			get { return KarelRobot.LookingToNorth; }
		}

		/// <summary>
		/// Gets or sets the world position.
		/// </summary>
		/// <value>The world position.</value>
		public Point WorldPosition
		{
			get { return KarelRobot.WorldPosition; }
			set { KarelRobot.WorldPosition = value; }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to west].
		/// </summary>
		/// <value><c>true</c> if [looking to west]; otherwise, <c>false</c>.</value>
		public bool LookingToWest
		{
			get { return KarelRobot.LookingToWest; }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to east].
		/// </summary>
		/// <value><c>true</c> if [looking to east]; otherwise, <c>false</c>.</value>
		public bool LookingToEast
		{
			get { return KarelRobot.LookingToEast; }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to south].
		/// </summary>
		/// <value><c>true</c> if [looking to south]; otherwise, <c>false</c>.</value>
		public bool LookingToSouth
		{
			get { return KarelRobot.LookingToSouth; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance has beeper.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has beeper; otherwise, <c>false</c>.
		/// </value>
		public bool HasBeeper
		{
			get { return KarelRobot.HasBeeper; }
		}

		/// <summary>
		/// Lookings to.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <returns></returns>
		public bool LookingTo(KarelDirection direction)
		{
			return KarelRobot.LookingTo(direction);
		}

		/// <summary>
		/// Determines whether [has found beeper].
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if [has found beeper]; otherwise, <c>false</c>.
		/// </returns>
		public bool HasFoundBeeper()
		{
			return KarelRobot.HasFoundBeeper();
		}

		/// <summary>
		/// Determines whether this instance can move.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if this instance can move; otherwise, <c>false</c>.
		/// </returns>
		public bool CanMove()
		{
			return KarelRobot.CanMove();
		}

		/// <summary>
		/// Turns the on.
		/// </summary>
		public void TurnOn()
		{
			KarelRobot.TurnOn();
			WaitPendingActions();
		}

		/// <summary>
		/// Turns the off.
		/// </summary>
		public void TurnOff()
		{
			KarelRobot.TurnOff();
			WaitPendingActions();
		}

		/// <summary>
		/// Moves this instance.
		/// </summary>
		public void Move()
		{
			KarelRobot.Move();
			WaitPendingActions();
		}

		/// <summary>
		/// Turns the left.
		/// </summary>
		public void TurnLeft()
		{
			KarelRobot.TurnLeft();
			WaitPendingActions();
		}

		/// <summary>
		/// Picks the beeper.
		/// </summary>
		public void PickBeeper()
		{
			KarelRobot.PickBeeper();
			WaitPendingActions();
		}

		/// <summary>
		/// Puts the beeper.
		/// </summary>
		public void PutBeeper()
		{
			KarelRobot.PutBeeper();
			WaitPendingActions();
		}

		/// <summary>
		/// Waits the pending actions.
		/// </summary>
		private void WaitPendingActions()
		{
			while (KarelRobot.HasPendingActions) {
				Thread.Sleep(100);
			}
		}
	}
}