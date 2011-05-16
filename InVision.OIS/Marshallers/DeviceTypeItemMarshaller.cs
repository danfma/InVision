using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Marshallers
{
	internal class DeviceTypeItemMarshaller : ICustomMarshaler
	{
		/// <summary>
		/// Converts the unmanaged data to managed data.
		/// </summary>
		/// <returns>
		/// An object that represents the managed view of the COM data.
		/// </returns>
		/// <param name="pNativeData">A pointer to the unmanaged data to be wrapped. </param>
		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Converts the managed data to unmanaged data.
		/// </summary>
		/// <returns>
		/// A pointer to the COM view of the managed object.
		/// </returns>
		/// <param name="ManagedObj">The managed object to be converted. </param>
		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Performs necessary cleanup of the unmanaged data when it is no longer needed.
		/// </summary>
		/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed. </param>
		public void CleanUpNativeData(IntPtr pNativeData)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Performs necessary cleanup of the managed data when it is no longer needed.
		/// </summary>
		/// <param name="ManagedObj">The managed object to be destroyed. </param>
		public void CleanUpManagedData(object ManagedObj)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns the size of the native data to be marshaled.
		/// </summary>
		/// <returns>
		/// The size, in bytes, of the native data.
		/// </returns>
		public int GetNativeDataSize()
		{
			throw new NotImplementedException();
		}
	}
}