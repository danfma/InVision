using System;
using System.Collections.Generic;
using InVision.GameMath;

namespace Karel
{
	public class WorldSpace : KarelWorldComponent
	{
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
		/// Gets or sets a value indicating whether this instance has karel.
		/// </summary>
		/// <value><c>true</c> if this instance has karel; otherwise, <c>false</c>.</value>
		public bool HasKarel { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has block.
		/// </summary>
		/// <value><c>true</c> if this instance has block; otherwise, <c>false</c>.</value>
		public bool HasBlock { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has beeper.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has beeper; otherwise, <c>false</c>.
		/// </value>
		public bool HasBeeper { get; private set; }

		/// <summary>
		/// Tries the add.
		/// </summary>
		/// <param name="childName">Name of the child.</param>
		/// <param name="child">The child.</param>
		/// <returns></returns>
		public bool TryAdd(string childName, KarelWorldComponent child)
		{
			if (child is KarelBeeper)
			{
				if (HasBeeper)
					return false;

				Children.Add(childName, child);
				HasBeeper = true;
				return true;
			}

			if (child is KarelBlock)
			{
				if (HasBlock)
					return false;

				Children.Add(childName, child);
				HasBlock = true;
				return true;
			}

			if (child is KarelRobot)
			{
				if (HasKarel)
					return false;

				Children.Add(childName, child);
				HasKarel = true;
				return true;
			}

			Children.Add(childName, child);
			return true;
		}
	}
}