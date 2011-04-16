using System;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class Component : Handle, IComponent
	{
		private ComponentExtended nativeRef;

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
		/// <param name="extended">The extended.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal Component(ComponentExtended extended, bool ownsHandle = false)
			: base(extended.Self, ownsHandle)
		{
			nativeRef = extended;
		}

		#region IComponent Members

		/// <summary>
		/// Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return nativeRef.ComponentType; }
		}

		#endregion

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeComponent.Delete(handle);
			nativeRef = default(ComponentExtended);
		}
	}
}