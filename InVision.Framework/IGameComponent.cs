using System;
using System.Collections.Generic;
using InVision.Framework.Actions;
using InVision.GameMath;

namespace InVision.Framework
{
	public interface IGameComponent : ICloneable, IDisposable
	{
		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		Vector3 Position { get; set; }

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
		/// <param name="time">The time.</param>
		/// <returns></returns>
		IEnumerable<UpdateAction> UpdateBySteps(ElapsedTime time);
	}
}