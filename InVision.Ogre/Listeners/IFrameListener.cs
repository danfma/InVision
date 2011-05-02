namespace InVision.Rendering.Listeners
{
	public interface IFrameListener
	{
		/// <summary>
		/// Called when [frame started].
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns></returns>
		bool OnFrameStarted(FrameEvent e);

		/// <summary>
		/// Called when [frame ended].
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns></returns>
		bool OnFrameEnded(FrameEvent e);
	}
}