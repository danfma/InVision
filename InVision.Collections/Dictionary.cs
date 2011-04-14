using System;

namespace InVision.Collections
{
	public class Dictionary<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue>, INativeCollection
	{
		#region INativeCollection Members

		/// <summary>
		/// Gets or sets the synchronizer.
		/// </summary>
		/// <value>The synchronizer.</value>
		public INativeCollectionSynchronizer Synchronizer { get; set; }

		/// <summary>
		/// Reloads this instance.
		/// </summary>
		public void Reload()
		{
			if (Synchronizer != null)
				Synchronizer.Reload(this);
		}

		/// <summary>
		/// Flushes this instance.
		/// </summary>
		public void Flush()
		{
			if (Synchronizer != null)
				Synchronizer.Flush(this);
		}

		#endregion
	}
}