using System;
using InVision.Native.Collections;

namespace InVision.OIS
{
	public class DeviceList : MultiDictionary<DeviceType, string>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DeviceList"/> class.
		/// </summary>
		public DeviceList()
		{
			Synchronizer = new NativeSynchronizer();
		}

		#region Nested type: NativeSynchronizer

		private sealed class NativeSynchronizer : INativeCollectionSynchronizer
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