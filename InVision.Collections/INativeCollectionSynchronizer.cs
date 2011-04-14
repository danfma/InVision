namespace InVision.Collections
{
	public interface INativeCollectionSynchronizer
	{
		/// <summary>
		/// Reloads the specified native collection.
		/// </summary>
		/// <param name="nativeCollection">The native collection.</param>
		void Reload(INativeCollection nativeCollection);

		/// <summary>
		/// Flushes the specified native collection.
		/// </summary>
		/// <param name="nativeCollection">The native collection.</param>
		void Flush(INativeCollection nativeCollection);
	}
}