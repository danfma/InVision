using System;
using System.Collections.Generic;
using InVision.Framework.Components.Actions;
using InVision.GameMath;

namespace InVision.Framework.Components
{
	public interface IGameComponent : ICloneable, IDisposable, IUpdateActionCreator
	{
		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		Vector3 Position { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [repeat update steps].
		/// </summary>
		/// <value><c>true</c> if [repeat update steps]; otherwise, <c>false</c>.</value>
		bool RepeatUpdateSteps { get; set; }

		/// <summary>
		/// Gets the children.
		/// </summary>
		/// <value>The children.</value>
		GameComponentCollection Children { get; }

		/// <summary>
		/// Gets a value indicating whether this <see cref="IGameComponent"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized { get; }

		/// <summary>
		/// Gets a value indicating whether this instance is dead.
		/// </summary>
		/// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
		bool IsDead { get; }

		/// <summary>
		/// Gets or sets the game application.
		/// </summary>
		/// <value>The game application.</value>
		GameApplication GameApplication { get; set; }

		/// <summary>
		/// Gets or sets the game variables.
		/// </summary>
		/// <value>The game variables.</value>
		dynamic GameVariables { get; set; }

		/// <summary>
		/// Gets or sets the state variables.
		/// </summary>
		/// <value>The state variables.</value>
		dynamic StateVariables { get; set; }

		/// <summary>
		/// Initializes the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		void Initialize(GameApplication app);

		/// <summary>
		/// Updates the specified time.
		/// </summary>
		/// <param name="time">The time.</param>
		void Update(ElapsedTime time);

		/// <summary>
		/// Updates the by steps.
		/// </summary>
		/// <returns></returns>
		IEnumerable<UpdateAction> UpdateBySteps();
	}
}