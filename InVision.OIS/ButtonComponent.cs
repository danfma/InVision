using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.OIS
{
	[StructLayout(LayoutKind.Sequential)]
	public struct ButtonComponent : IButtonComponent, IHandleHolder
	{
		private readonly IntPtr handle;
		private readonly ComponentType componentType;
		private readonly bool pushed;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ButtonComponent" /> struct.
		/// </summary>
		/// <param name = "handle">The handle.</param>
		/// <param name = "componentType">Type of the component.</param>
		/// <param name = "pushed">if set to <c>true</c> [is pushed].</param>
		internal ButtonComponent(IntPtr handle, ComponentType componentType, bool pushed)
		{
			this.handle = handle;
			this.componentType = componentType;
			this.pushed = pushed;
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ButtonComponent" /> struct.
		/// </summary>
		/// <param name = "pushed">if set to <c>true</c> [is pushed].</param>
		/// <param name = "componentType">Type of the component.</param>
		public ButtonComponent(ComponentType componentType, bool pushed)
		{
			handle = IntPtr.Zero;
			this.componentType = componentType;
			this.pushed = pushed;
		}

		#region IButton Members

		/// <summary>
		/// 	Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return componentType; }
		}

		/// <summary>
		/// 	Gets a value indicating whether this instance is pushed.
		/// </summary>
		/// <value><c>true</c> if this instance is pushed; otherwise, <c>false</c>.</value>
		public bool Pushed
		{
			get { return pushed; }
		}

		#endregion

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
	}
}