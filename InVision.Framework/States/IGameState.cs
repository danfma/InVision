using System;
using InVision.Framework.Components;

namespace InVision.Framework.States
{
	public interface IGameState : IDisposable
	{
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; }

		/// <summary>
		/// Gets the state variables.
		/// </summary>
		/// <value>The state variables.</value>
		dynamic StateVariables { get; }

		/// <summary>
		/// Gets the components.
		/// </summary>
		/// <value>The components.</value>
		GameComponentCollection Components { get; }

		/// <summary>
		/// Gets or sets the state machine.
		/// </summary>
		/// <value>The state machine.</value>
		GameStateMachine StateMachine { get; set; }

		/// <summary>
		/// Gets or sets the game application.
		/// </summary>
		/// <value>The game application.</value>
		GameApplication GameApplication { get; set; }

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		void Initialize();

		/// <summary>
		/// Updates the specified elapsed time.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		void Update(ElapsedTime elapsedTime);
	}
}