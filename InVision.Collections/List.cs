using System;
using System.Collections.Generic;

namespace InVision.Collections
{
	public class List<T> : System.Collections.Generic.List<T>, INativeCollection
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="List&lt;T&gt;"/> class.
		/// </summary>
		public List()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="List&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		public List(int capacity)
			: base(capacity)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="List&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="collection">The collection.</param>
		public List(IEnumerable<T> collection)
			: base(collection)
		{
		}

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
	}
}