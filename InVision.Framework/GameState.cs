using System;

namespace InVision.Framework
{
	public abstract class GameState : DisposableObject, IGameState
	{
		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="GameState"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		protected GameState(string name)
		{
			Name = name;
			Components = new GameComponentCollection();
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Components != null)
				Components.Dispose();

			if (disposing)
			{
				Name = null;
				Components = null;
			}
		}

		#endregion

		#region IGameState Members

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; protected set; }

		/// <summary>
		/// Gets the components.
		/// </summary>
		/// <value>The components.</value>
		public GameComponentCollection Components { get; protected set; }

		/// <summary>
		/// Gets or sets the state machine.
		/// </summary>
		/// <value>The state machine.</value>
		public GameStateMachine StateMachine { get; set; }

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public abstract void Initialize();

		/// <summary>
		/// Begins the frame.
		/// </summary>
		/// <param name="timer"></param>
		public virtual void BeginFrame(ElapsedTime timer = default(ElapsedTime)) { }

		/// <summary>
		/// Ends the frame.
		/// </summary>
		public virtual void EndFrame() { }

		#endregion
	}
}