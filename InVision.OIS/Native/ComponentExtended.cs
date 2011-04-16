using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct ComponentExtended
	{
		private readonly IntPtr self;
		private readonly ComponentType* pComponentType;

		/// <summary>
		/// Initializes a new instance of the <see cref="ComponentExtended"/> struct.
		/// </summary>
		/// <param name="self">The handle.</param>
		/// <param name="pComponentType">Type of the p component.</param>
		public ComponentExtended(IntPtr self, ComponentType* pComponentType)
		{
			this.self = self;
			this.pComponentType = pComponentType;
		}

		/// <summary>
		/// Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		public IntPtr Self
		{
			get { return self; }
		}

		/// <summary>
		/// Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return *pComponentType; }
		}
	}
}