using System.Collections.Generic;

namespace InVision.Framework
{
	/// <summary>
	/// 
	/// </summary>
	public interface IGameLogic
	{
		/// <summary>
		/// Updates the specified game time.
		/// </summary>
		/// <param name="elapsedTime">The game time.</param>
		IEnumerable<StepAction> Update(ElapsedTime elapsedTime);
	}
}