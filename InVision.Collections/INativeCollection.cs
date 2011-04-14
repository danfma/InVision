namespace InVision.Collections
{
	public interface INativeCollection
	{
		/// <summary>
		/// Gets or sets the synchronizer.
		/// </summary>
		/// <value>The synchronizer.</value>
		INativeCollectionSynchronizer Synchronizer { get; set; }

		/// <summary>
		/// Reloads this instance.
		/// </summary>
		void Reload();

		/// <summary>
		/// Flushes this instance.
		/// </summary>
		void Flush();
	}
}