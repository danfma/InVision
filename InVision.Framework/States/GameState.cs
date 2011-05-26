using System;
using System.Dynamic;
using InVision.Framework.Components;

namespace InVision.Framework.States
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
			StateVariables = new ExpandoObject();
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Components != null)
				Components.Dispose();

			if (!disposing) 
				return;

			Name = null;
			Components = null;
			StateVariables = null;
			GameApplication = null;
		}

		#endregion

		#region IGameState Members

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; protected set; }

		/// <summary>
		/// Gets the state variables.
		/// </summary>
		/// <value>The state variables.</value>
		public dynamic StateVariables { get; private set; }

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
		/// Gets or sets the game application.
		/// </summary>
		/// <value>The game application.</value>
		public GameApplication GameApplication { get; set; }

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public virtual void Initialize()
		{
			foreach (var component in Components)
			{
				component.GameApplication = GameApplication;
				component.GameVariables = GameApplication.GlobalVariables;
				component.StateVariables = StateVariables;
			}
		}

		/// <summary>
		/// Updates the specified elapsed time.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		public virtual void Update(ElapsedTime elapsedTime)
		{
			foreach (var component in Components)
			{
				component.Update(elapsedTime);
			}
		}

		#endregion
	}
}