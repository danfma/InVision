namespace InVision.Framework.Scripting
{
	public interface IScriptable
	{
		/// <summary>
		/// Gets the script.
		/// </summary>
		/// <value>The script.</value>
		IScript Script { get; }

		/// <summary>
		/// Reloads this instance.
		/// </summary>
		void Reload();
	}
}