using System.Collections.Generic;
using InVision.Framework.Components.Actions;

namespace InVision.Framework.Components
{
	public interface IGameLogic
	{
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; }

		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		/// <value>The game.</value>
		GameApplication Game { get; set; }

		/// <summary>
		/// Updates the specified elapsed time.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		void Update(ElapsedTime elapsedTime);

		/// <summary>
		/// Updates the by steps.
		/// </summary>
		/// <returns></returns>
		IEnumerable<UpdateAction> UpdateBySteps();
	}
}