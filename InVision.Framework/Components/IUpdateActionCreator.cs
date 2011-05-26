using System;
using InVision.Framework.Components.Actions;

namespace InVision.Framework.Components
{
	public interface IUpdateActionCreator
	{
		/// <summary>
		/// Waits the by.
		/// </summary>
		/// <param name="milliseconds">The milliseconds.</param>
		/// <returns></returns>
		UpdateAction WaitBy(long milliseconds);

		/// <summary>
		/// Waits the by.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <returns></returns>
		UpdateAction WaitBy(TimeSpan time);
	}
}