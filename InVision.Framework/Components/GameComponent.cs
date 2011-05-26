using System;
using System.Collections.Generic;
using System.Linq;
using InVision.Framework.Components.Actions;
using InVision.GameMath;

namespace InVision.Framework.Components
{
	public abstract class GameComponent : DisposableObject, IGameComponent
	{
		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="GameComponent"/> class.
		/// </summary>
		protected GameComponent()
		{
			Children = new GameComponentCollection();
			ActionProcessor = new ActionProcessor(UpdateBySteps());
		}

		/// <summary>
		/// Gets or sets the action processor.
		/// </summary>
		/// <value>The action processor.</value>
		protected ActionProcessor ActionProcessor { get; private set; }

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Children != null)
			{
				foreach (IGameComponent child in Children)
				{
					child.Dispose();
				}

				Children.Clear();
			}

			if (disposing)
			{
				Children = null;
				ActionProcessor = null;
			}
		}

		#endregion

		#region IGameComponent Members

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>
		/// A new object that is a copy of this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public virtual object Clone()
		{
			return MemberwiseClone();
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public virtual Vector3 Position { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [repeat update steps].
		/// </summary>
		/// <value><c>true</c> if [repeat update steps]; otherwise, <c>false</c>.</value>
		public bool RepeatUpdateSteps { get; set; }

		/// <summary>
		/// Gets the children.
		/// </summary>
		/// <value>The children.</value>
		public GameComponentCollection Children { get; private set; }

		/// <summary>
		/// Gets a value indicating whether this <see cref="IGameComponent"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		public bool Initialized { get; private set; }

		/// <summary>
		/// Gets a value indicating whether this instance is dead.
		/// </summary>
		/// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
		public bool IsDead
		{
			get { return !ActionProcessor.IsProcessing && !RepeatUpdateSteps; }
		}

		/// <summary>
		/// Gets or sets the game application.
		/// </summary>
		/// <value>The game application.</value>
		public GameApplication GameApplication { get; set; }

		/// <summary>
		/// Gets or sets the game variables.
		/// </summary>
		/// <value>The game variables.</value>
		public dynamic GameVariables { get; set; }

		/// <summary>
		/// Gets or sets the state variables.
		/// </summary>
		/// <value>The state variables.</value>
		public dynamic StateVariables { get; set; }

		/// <summary>
		/// Initializes the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		public virtual void Initialize(GameApplication app)
		{
			InitializeSelf(app);
			InitializeChildren(app);

			Initialized = true;
		}

		/// <summary>
		/// Updates the specified game time.
		/// </summary>
		/// <param name="elapsedTime">The game time.</param>
		public virtual void Update(ElapsedTime elapsedTime)
		{
			UpdateSelf(elapsedTime);
			UpdateChildren(elapsedTime);
		}

		/// <summary>
		/// Updates the by steps.
		/// </summary>
		/// <returns></returns>
		public virtual IEnumerable<UpdateAction> UpdateBySteps()
		{
			return Enumerable.Empty<UpdateAction>();
		}

		/// <summary>
		/// Waits the by.
		/// </summary>
		/// <param name="milliseconds">The milliseconds.</param>
		/// <returns></returns>
		public UpdateAction WaitBy(long milliseconds)
		{
			return new WaitTimeUpdateAction(milliseconds);
		}

		/// <summary>
		/// Waits the by.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <returns></returns>
		public UpdateAction WaitBy(TimeSpan time)
		{
			return new WaitTimeUpdateAction((long)time.TotalMilliseconds);
		}

		#endregion

		/// <summary>
		/// Initializes the self.
		/// </summary>
		/// <param name="app">The app.</param>
		protected virtual void InitializeSelf(GameApplication app)
		{
		}

		/// <summary>
		/// Initializes the children.
		/// </summary>
		/// <param name="app">The app.</param>
		protected virtual void InitializeChildren(GameApplication app)
		{
			foreach (IGameComponent child in Children)
			{
				child.Initialize(app);
			}
		}

		/// <summary>
		/// Gets or sets the elapsed time.
		/// </summary>
		/// <value>The elapsed time.</value>
		protected ElapsedTime ElapsedTime { get; private set; }

		/// <summary>
		/// Updates the self.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected virtual void UpdateSelf(ElapsedTime elapsedTime)
		{
			ElapsedTime = elapsedTime;
			ActionProcessor.Step(elapsedTime);

			if (ActionProcessor.IsProcessing)
				return;

			if (RepeatUpdateSteps)
				ActionProcessor.Reset();
		}

		/// <summary>
		/// Updates the children.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected virtual void UpdateChildren(ElapsedTime elapsedTime)
		{
			foreach (IGameComponent child in Children)
			{
				child.Update(elapsedTime);
			}
		}
	}
}