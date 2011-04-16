using System;
using System.Collections.Generic;
using InVision.Native.Collections;

namespace InVision.OIS
{
	public class FactoryList : InVision.Native.Collections.List<IFactoryCreator>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FactoryList"/> class.
		/// </summary>
		public FactoryList()
		{
			Synchronizer = new NativeSynchronizer();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FactoryList"/> class.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		public FactoryList(int capacity)
			: base(capacity)
		{
			Synchronizer = new NativeSynchronizer();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FactoryList"/> class.
		/// </summary>
		/// <param name="collection">The collection.</param>
		public FactoryList(IEnumerable<IFactoryCreator> collection)
			: base(collection)
		{
			Synchronizer = new NativeSynchronizer();
		}

		#region Nested type: NativeSynchronizer

		private class NativeSynchronizer : INativeCollectionSynchronizer
		{
			#region INativeCollectionSynchronizer Members

			/// <summary>
			/// Reloads the specified native collection.
			/// </summary>
			/// <param name="nativeCollection">The native collection.</param>
			public void Reload(INativeCollection nativeCollection)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			/// Flushes the specified native collection.
			/// </summary>
			/// <param name="nativeCollection">The native collection.</param>
			public void Flush(INativeCollection nativeCollection)
			{
				throw new NotImplementedException();
			}

			#endregion
		}

		#endregion
	}
}