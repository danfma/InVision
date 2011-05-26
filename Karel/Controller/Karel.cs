using System;
using InVision.GameMath;

namespace Karel.Controller
{
	public class Karel
	{
		/// <summary>
		/// Gets the karel instance.
		/// </summary>
		/// <value>The karel instance.</value>
		private static KarelRobot KarelInstance
		{
			get { return World != null ? World.Karel : null; }
		}

		/// <summary>
		/// Gets the world.
		/// </summary>
		/// <value>The world.</value>
		private static KarelWorld World
		{
			get { return KarelWorld.Instance; }
		}

		/// <summary>
		/// Gets or sets the direction.
		/// </summary>
		/// <value>The direction.</value>
		public KarelDirection Direction
		{
			get { return KarelInstance.Direction; }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to north].
		/// </summary>
		/// <value><c>true</c> if [looking to north]; otherwise, <c>false</c>.</value>
		public bool LookingToNorth
		{
			get { return KarelInstance.LookingToNorth; }
		}

		/// <summary>
		/// Gets or sets the world position.
		/// </summary>
		/// <value>The world position.</value>
		public Vector2 WorldPosition
		{
			get { return KarelInstance.WorldPosition; }
			set { KarelInstance.WorldPosition = value; }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to west].
		/// </summary>
		/// <value><c>true</c> if [looking to west]; otherwise, <c>false</c>.</value>
		public bool LookingToWest
		{
			get { return KarelInstance.LookingToWest; }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to east].
		/// </summary>
		/// <value><c>true</c> if [looking to east]; otherwise, <c>false</c>.</value>
		public bool LookingToEast
		{
			get { return KarelInstance.LookingToEast; }
		}

		/// <summary>
		/// Gets a value indicating whether [looking to south].
		/// </summary>
		/// <value><c>true</c> if [looking to south]; otherwise, <c>false</c>.</value>
		public bool LookingToSouth
		{
			get { return KarelInstance.LookingToSouth; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance has beeper.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has beeper; otherwise, <c>false</c>.
		/// </value>
		public bool HasBeeper
		{
			get { return KarelInstance.HasBeeper; }
		}

		/// <summary>
		/// Lookings to.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <returns></returns>
		public bool LookingTo(KarelDirection direction)
		{
			return KarelInstance.LookingTo(direction);
		}

		/// <summary>
		/// Determines whether [has found beeper].
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if [has found beeper]; otherwise, <c>false</c>.
		/// </returns>
		public bool HasFoundBeeper()
		{
			return KarelInstance.HasFoundBeeper();
		}

		/// <summary>
		/// Determines whether this instance can move.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if this instance can move; otherwise, <c>false</c>.
		/// </returns>
		public bool CanMove()
		{
			return KarelInstance.CanMove();
		}

		/// <summary>
		/// Turns the on.
		/// </summary>
		public void TurnOn()
		{
			KarelInstance.TurnOn();
		}

		/// <summary>
		/// Turns the off.
		/// </summary>
		public void TurnOff()
		{
			KarelInstance.TurnOff();
		}

		/// <summary>
		/// Moves this instance.
		/// </summary>
		public void Move()
		{
			KarelInstance.Move();
		}

		/// <summary>
		/// Turns the left.
		/// </summary>
		public void TurnLeft()
		{
			KarelInstance.TurnLeft();
		}

		/// <summary>
		/// Picks the beeper.
		/// </summary>
		public static void PickBeeper()
		{
			KarelInstance.PickBeeper();
		}

		/// <summary>
		/// Puts the beeper.
		/// </summary>
		public void PutBeeper()
		{
			KarelInstance.PutBeeper();
		}
	}
}