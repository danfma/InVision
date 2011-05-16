using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;
using InVision.OIS.Components;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct ComponentDescriptor
	{
		private readonly Handle _handle;
		private readonly ComponentType* _ctype;

		/// <summary>
		/// Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		public Handle Handle
		{
			get { return _handle; }
		}

		/// <summary>
		/// Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return *_ctype; }
		}
	}
}