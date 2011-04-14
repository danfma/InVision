using System;
using System.Collections.Generic;
using InVision.Collections;

namespace InVision.OIS
{
	public class ParamList : MultiDictionary<string, string>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ParamList"/> class.
		/// </summary>
		public ParamList()
		{
			Synchronizer = new NativeSynchronizer();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParamList"/> class.
		/// </summary>
		/// <param name="collection">The collection.</param>
		public ParamList(IEnumerable<KeyValuePair<string, string>> collection)
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

	public class InputManager : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InputManager"/> class.
		/// </summary>
		/// <param name="winHandle">The win handle.</param>
		public InputManager(IntPtr winHandle)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InputManager"/> class.
		/// </summary>
		/// <param name="paramList">The param list.</param>
		public InputManager(ParamList paramList)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get { throw new NotImplementedException(); } }

		/// <summary>
		/// Gets the number of devices.
		/// </summary>
		/// <value>The number of devices.</value>
		public int GetNumberOfDevices(ObjectInterfaceType type)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Lists the free devices.
		/// </summary>
		/// <returns></returns>
		public DeviceList ListFreeDevices()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates the input object.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="bufferMode">if set to <c>true</c> [buffer mode].</param>
		/// <param name="vendor">The vendor.</param>
		/// <returns></returns>
		public IDevice CreateInputObject(ObjectInterfaceType type, bool bufferMode, string vendor = "")
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Destroys the input object.
		/// </summary>
		/// <param name="device">The input object.</param>
		public void DestroyInputObject(IDevice device)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Adds the factory creator.
		/// </summary>
		/// <param name="factory">The factory.</param>
		public void AddFactoryCreator(IFactoryCreator factory)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Removes the factory creator.
		/// </summary>
		/// <param name="factory">The factory.</param>
		public void RemoveFactoryCreator(IFactoryCreator factory)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Enables the add on factory.
		/// </summary>
		/// <param name="addOnFactory">The add on factory.</param>
		public void EnableAddOnFactory(AddOnFactory addOnFactory)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the version number.
		/// </summary>
		/// <value>The version number.</value>
		public static int VersionNumber { get { throw new NotImplementedException(); } }

		/// <summary>
		/// Gets the name of the version.
		/// </summary>
		/// <value>The name of the version.</value>
		public static string VersionName { get { throw new NotImplementedException(); } }


		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public enum AddOnFactory
	{
		/// <summary>
		/// 
		/// </summary>
		All = 0,
		/// <summary>
		/// 
		/// </summary>
		LIRC = 1,
		/// <summary>
		/// 
		/// </summary>
		WiiMote = 2
	}

	public class EventArgs : System.EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EventArgs"/> class.
		/// </summary>
		/// <param name="device">The device.</param>
		public EventArgs(IDevice device = null)
		{
			Device = device;
		}

		/// <summary>
		/// Gets or sets the device.
		/// </summary>
		/// <value>The device.</value>
		public IDevice Device { get; private set; }
	}
}