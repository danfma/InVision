namespace InVision.Framework.Config
{
	public interface IConfigurationSection
	{
		/// <summary>
		/// Gets a value indicating whether this instance has changes.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has changes; otherwise, <c>false</c>.
		/// </value>
		bool HasChanges { get; }

		/// <summary>
		/// Flushes this instance.
		/// </summary>
		void Flush();
	}
}