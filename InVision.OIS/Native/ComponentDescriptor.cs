using System;
using System.Runtime.InteropServices;
using InVision.OIS.Components;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct ComponentDescriptor
	{
		private readonly IntPtr _self;
		private readonly ComponentType* _componentType;

		/// <summary>
		/// Initializes a new instance of the <see cref="ComponentDescriptor"/> struct.
		/// </summary>
		/// <param name="self">The handle.</param>
		/// <param name="componentType">Type of the p component.</param>
		public ComponentDescriptor(IntPtr self, ComponentType* componentType)
		{
			_self = self;
			_componentType = componentType;
		}

		/// <summary>
		/// Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		public IntPtr Self
		{
			get { return _self; }
		}

		/// <summary>
		/// Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return *_componentType; }
		}
	}
}