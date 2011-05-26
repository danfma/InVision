using System;
using InVision.Framework;

namespace Tutano
{
	public abstract class TutanoGameFlow : GameFlow
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TutanoGameFlow"/> class.
		/// </summary>
		/// <param name="tutanoApp">The tutano app.</param>
		public TutanoGameFlow(TutanoApplication tutanoApp)
		{
			TutanoApp = tutanoApp;
		}

		/// <summary>
		/// Gets or sets the tutano app.
		/// </summary>
		/// <value>The tutano app.</value>
		public TutanoApplication TutanoApp { get; private set; }
	}
}