using System;

namespace InVision.Framework
{
	public interface IGameState : IDisposable
	{
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; }

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
		/// Initializes this instance.
		/// </summary>
		void Initialize();

		/// <summary>
		/// Begins the frame.
		/// </summary>
		/// <param name="timer"></param>
		void BeginFrame(ElapsedTime timer = default(ElapsedTime));

		/// <summary>
		/// Ends the frame.
		/// </summary>
		void EndFrame();
	}
}