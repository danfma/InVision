using System;
using System.Collections.Generic;
using InVision.Framework.Actions;
using InVision.GameMath;

namespace InVision.Framework
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
		}

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
				Children = null;
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
		/// <param name="time">The time.</param>
		/// <returns></returns>
		public virtual IEnumerable<UpdateAction> UpdateBySteps(ElapsedTime time)
		{
			yield break;
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
		/// Updates the self.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected virtual void UpdateSelf(ElapsedTime elapsedTime)
		{

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