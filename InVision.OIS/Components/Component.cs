using System;
using InVision.Native.Ext;
using InVision.OIS.Native;

namespace InVision.OIS.Components
{
	public class Component : HandleContainer
	{
		private ComponentDescriptor _descriptor;

		/// <summary>
		/// Initializes a new instance of the <see cref="Component"/> class.
		/// </summary>
		/// <param name="componentType">Type of the component.</param>
		public Component(ComponentType componentType)
			: this(NativeComponent.New(componentType), true)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Component"/> class.
		/// </summary>
		/// <param name="descriptor">The extended.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal Component(ComponentDescriptor descriptor, bool ownsHandle = false)
			: base(descriptor.Handle, ownsHandle)
		{
			_descriptor = descriptor;
		}

		/// <summary>
		/// Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return _descriptor.ComponentType; }
		}

		/// <summary>
		/// Deletes the handle.
		/// </summary>
		protected override void DeleteHandle()
		{
			NativeComponent.Delete(SelfHandle);
			_descriptor = new ComponentDescriptor();
		}
	}
}