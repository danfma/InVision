using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.OIS
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Vector3Component : IVector3Component, IHandleHolder
	{
		private readonly IntPtr handle;
		private readonly ComponentType componentType;
		private readonly float x;
		private readonly float y;
		private readonly float z;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Vector3Component" /> struct.
		/// </summary>
		/// <param name = "handle">The handle.</param>
		/// <param name = "componentType">Type of the component.</param>
		/// <param name = "x">The x.</param>
		/// <param name = "y">The y.</param>
		/// <param name = "z">The z.</param>
		internal Vector3Component(IntPtr handle, ComponentType componentType, float x, float y, float z)
		{
			this.handle = handle;
			this.componentType = componentType;
			this.x = x;
			this.y = y;
			this.z = z;
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Vector3Component" /> struct.
		/// </summary>
		/// <param name = "componentType">Type of the component.</param>
		/// <param name = "x">The x.</param>
		/// <param name = "y">The y.</param>
		/// <param name = "z">The z.</param>
		public Vector3Component(ComponentType componentType, float x, float y, float z)
		{
			handle = IntPtr.Zero;
			this.componentType = componentType;
			this.x = x;
			this.y = y;
			this.z = z;
		}

		#region IHandleHolder Members

		/// <summary>
		/// 	Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		IntPtr IHandleHolder.Handle
		{
			get { return handle; }
		}

		#endregion

		#region IVector3 Members

		/// <summary>
		/// 	Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return componentType; }
		}

		/// <summary>
		/// 	Gets the X.
		/// </summary>
		/// <value>The X.</value>
		public float X
		{
			get { return x; }
		}

		/// <summary>
		/// 	Gets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public float Y
		{
			get { return y; }
		}

		/// <summary>
		/// 	Gets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public float Z
		{
			get { return z; }
		}

		#endregion
	}
}