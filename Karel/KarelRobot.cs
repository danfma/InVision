using System;
using InVision.Framework;
using InVision.GameMath;

namespace Karel
{
	public class KarelRobot : KarelWorldComponent
	{
		/// <summary>
		/// Gets or sets the direction.
		/// </summary>
		/// <value>The direction.</value>
		public KarelDirection Direction { get; private set; }

		/// <summary>
		/// Gets a value indicating whether [looking to north].
		/// </summary>
		/// <value><c>true</c> if [looking to north]; otherwise, <c>false</c>.</value>
		public bool LookingToNorth
		{
			get { return LookingTo(KarelDirection.North); }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to west].
		/// </summary>
		/// <value><c>true</c> if [looking to west]; otherwise, <c>false</c>.</value>
		public bool LookingToWest
		{
			get { return LookingTo(KarelDirection.West); }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to east].
		/// </summary>
		/// <value><c>true</c> if [looking to east]; otherwise, <c>false</c>.</value>
		public bool LookingToEast
		{
			get { return LookingTo(KarelDirection.East); }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to south].
		/// </summary>
		/// <value><c>true</c> if [looking to south]; otherwise, <c>false</c>.</value>
		public bool LookingToSouth
		{
			get { return LookingTo(KarelDirection.South); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance has beeper.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has beeper; otherwise, <c>false</c>.
		/// </value>
		public bool HasBeeper { get; private set; }

		/// <summary>
		/// Lookings to.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <returns></returns>
		public bool LookingTo(KarelDirection direction)
		{
			return Direction == direction;
		}

		/// <summary>
		/// Determines whether [has found beeper].
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if [has found beeper]; otherwise, <c>false</c>.
		/// </returns>
		public bool HasFoundBeeper()
		{
			return false;
		}

		/// <summary>
		/// Determines whether this instance can move.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if this instance can move; otherwise, <c>false</c>.
		/// </returns>
		public bool CanMove()
		{
			return true;
		}

		/// <summary>
		/// Turns the on.
		/// </summary>
		public void TurnOn()
		{
		}

		/// <summary>
		/// Turns the off.
		/// </summary>
		public void TurnOff()
		{
		}

		/// <summary>
		/// Moves this instance.
		/// </summary>
		public void Move()
		{
		}

		/// <summary>
		/// Turns the left.
		/// </summary>
		public void TurnLeft()
		{
		}

		/// <summary>
		/// Picks the beeper.
		/// </summary>
		public void PickBeeper()
		{
		}

		/// <summary>
		/// Puts the beeper.
		/// </summary>
		public void PutBeeper()
		{
		}

		/// <summary>
		/// Updates the self.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected override void UpdateSelf(ElapsedTime elapsedTime)
		{
			throw new NotImplementedException();
		}
	}
}