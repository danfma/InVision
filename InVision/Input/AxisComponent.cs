using System;
using System.Runtime.InteropServices;

namespace InVision.Input
{
	/// <summary>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct AxisComponent : IAxisComponent, IHandleHolder
	{
		private readonly IntPtr handle;
		private readonly ComponentType componentType;
		private readonly int absolute;
		private readonly int relative;
		private readonly bool absoluteOnly;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "AxisComponent" /> struct.
		/// </summary>
		/// <param name = "handle">The handle.</param>
		/// <param name = "componentType">Type of the component.</param>
		/// <param name = "absolute">The absolute.</param>
		/// <param name = "relative">The relative.</param>
		/// <param name = "absoluteOnly">if set to <c>true</c> [absolute only].</param>
		internal AxisComponent(IntPtr handle, ComponentType componentType, int absolute, int relative, bool absoluteOnly)
		{
			this.handle = handle;
			this.componentType = componentType;
			this.absolute = absolute;
			this.relative = relative;
			this.absoluteOnly = absoluteOnly;
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "AxisComponent" /> struct.
		/// </summary>
		/// <param name = "componentType">Type of the component.</param>
		/// <param name = "absolute">The absolute.</param>
		/// <param name = "relative">The relative.</param>
		/// <param name = "absoluteOnly">if set to <c>true</c> [absolute only].</param>
		public AxisComponent(ComponentType componentType, int absolute, int relative, bool absoluteOnly)
			: this()
		{
			handle = IntPtr.Zero;
			this.componentType = componentType;
			this.absolute = absolute;
			this.relative = relative;
			this.absoluteOnly = absoluteOnly;
		}

		/// <summary>
		/// 	Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return componentType; }
		}

		/// <summary>
		/// 	Gets the absolute.
		/// </summary>
		/// <value>The absolute.</value>
		public int Absolute
		{
			get { return absolute; }
		}

		/// <summary>
		/// 	Gets the relative.
		/// </summary>
		/// <value>The relative.</value>
		public int Relative
		{
			get { return relative; }
		}

		/// <summary>
		/// 	Gets a value indicating whether [absolute only].
		/// </summary>
		/// <value><c>true</c> if [absolute only]; otherwise, <c>false</c>.</value>
		public bool AbsoluteOnly
		{
			get { return absoluteOnly; }
		}

		/// <summary>
		/// 	Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		IntPtr IHandleHolder.Handle
		{
			get { return handle; }
		}
	}
}