using System;

namespace InVision.Framework.Components
{
	public abstract class GameLogic : GameComponent, IGameLogic
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GameLogic"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		protected GameLogic(string name)
		{
			Name = name;
		}

		#region IGameLogic Members

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; private set; }

		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		/// <value>The game.</value>
		public GameApplication Game { get; set; }

		#endregion
	}
}