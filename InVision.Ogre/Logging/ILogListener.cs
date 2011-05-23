namespace InVision.Ogre.Logging
{
	public interface ILogListener
	{
		/// <summary>
		/// Messages the logged.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="level">The level.</param>
		/// <param name="maskDebug">if set to <c>true</c> [mask debug].</param>
		/// <param name="name">The name.</param>
		void MessageLogged(string message, LogMessageLevel level, bool maskDebug, string name);
	}
}