using System;

namespace InVision.Framework.Components.Actions
{
	public class DelayedWorkUpdateAction : UpdateAction
	{
		private readonly Action _work;
		private bool _done;

		/// <summary>
		/// Initializes a new instance of the <see cref="DelayedWorkUpdateAction"/> class.
		/// </summary>
		/// <param name="work">The work.</param>
		public DelayedWorkUpdateAction(Action work)
		{
			_work = work;
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="UpdateAction"/> is done.
		/// </summary>
		/// <value><c>true</c> if done; otherwise, <c>false</c>.</value>
		public override bool Done
		{
			get { return _done; }
		}

		/// <summary>
		/// Updates the specified elapsed time.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		public override void Update(ElapsedTime elapsedTime)
		{
			_work();
			_done = true;
		}
	}
}