using System;
using System.Collections.Generic;
using InVision.Framework;
using InVision.GameMath;

namespace Karel
{
	public class WorldSpace : GameComponent
	{
		/// <summary>
		/// Updates the self.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected override void UpdateSelf(ElapsedTime elapsedTime)
		{

		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="WorldSpace"/> is checkpoint.
		/// </summary>
		/// <value><c>true</c> if checkpoint; otherwise, <c>false</c>.</value>
		public bool Checkpoint { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="WorldSpace"/> is deposit.
		/// </summary>
		/// <value><c>true</c> if deposit; otherwise, <c>false</c>.</value>
		public bool Deposit { get; set; }

		/// <summary>
		/// Gets or sets the allowed beeper colors.
		/// </summary>
		/// <value>The allowed beeper colors.</value>
		public List<Color> AllowedBeeperColors { get; private set; }

		/// <summary>
		/// Tries the add.
		/// </summary>
		/// <param name="childName">Name of the child.</param>
		/// <param name="child">The child.</param>
		/// <returns></returns>
		public bool TryAdd(string childName, KarelWorldComponent child)
		{

		}
	}
}