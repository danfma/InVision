using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class ComponentWrapper : IDisposable
	{
		private readonly IComponentWrapper wrapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="ComponentWrapper"/> class.
		/// </summary>
		/// <param name="componentType">Type of the component.</param>
		public ComponentWrapper(ComponentType componentType)
		{
			wrapper = NativeComponent.NewWrapper(componentType);
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="ComponentWrapper"/> is reclaimed by garbage collection.
		/// </summary>
		~ComponentWrapper()
		{
			Dispose(false);
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected void Dispose(bool disposing)
		{
			//wrapper.Dispose();
		}

		/// <summary>
		/// Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return wrapper.GetType(); }
		}
	}

	[Guid("5BD7A836-605B-4F2B-9934-877B2FD2FA54")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IComponentWrapper
	{
		[PreserveSig]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Dispose();

		[PreserveSig]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		ComponentType GetType();
	}
}
