using System;
using System.Collections.Generic;
using System.Linq;

namespace InVision.Framework.Components.Actions
{
	public sealed class ActionProcessor
	{
		private readonly IEnumerable<UpdateAction> _actions;

		/// <summary>
		/// Initializes a new instance of the <see cref="ActionProcessor"/> class.
		/// </summary>
		/// <param name="actions">The actions.</param>
		public ActionProcessor(IEnumerable<UpdateAction> actions)
		{
			_actions = actions;

			ActionEnumerator = actions == null ?
				Enumerable.Empty<UpdateAction>().GetEnumerator() :
				actions.GetEnumerator();

			Reset();
		}

		/// <summary>
		/// Gets a value indicating whether this instance is processing.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is processing; otherwise, <c>false</c>.
		/// </value>
		public bool IsProcessing { get; private set; }

		/// <summary>
		/// Gets or sets the current action.
		/// </summary>
		/// <value>The current action.</value>
		private UpdateAction CurrentAction { get; set; }

		/// <summary>
		/// Gets or sets the action enumerator.
		/// </summary>
		/// <value>The action enumerator.</value>
		private IEnumerator<UpdateAction> ActionEnumerator { get; set; }

		/// <summary>
		/// Steps the specified elapsed time.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		public void Step(ElapsedTime elapsedTime)
		{
			if (!IsProcessing)
				return;

			CurrentAction.Update(elapsedTime);

			if (!CurrentAction.Done)
				return;

			IsProcessing = ActionEnumerator.MoveNext();

			if (IsProcessing)
				CurrentAction = ActionEnumerator.Current;
		}

		/// <summary>
		/// Resets this instance.
		/// </summary>
		public void Reset()
		{
			ActionEnumerator = _actions.GetEnumerator();
			IsProcessing = ActionEnumerator.MoveNext();

			if (IsProcessing)
				CurrentAction = ActionEnumerator.Current;
		}
	}
}